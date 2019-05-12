# Encryption: Encryption At Rest

Encryption at rest is implemented at the storage layer, using Daniel J. Bernstein's `XChaCha20-Poly1305` authenticated encryption algorithm.

## What Does it Mean?

In [Voron](../../../server/storage/storage-engine), the storage engine behind RavenDB, data is stored in memory mapped files. This includes documents, indexes, attachments and transactions which are written to the journal.

If your disk is stolen or lost, an attacker will have full access to the raw data files and without encryption turned on the data can be read with very little effort.

On the other hand, when encryption is turned on the raw data is encrypted and unreadable without possession of the secret key.

In RavenDB, encryption is done at the lowest possible layer, the storage engine. It is fully transparent to other levels of the server, making it super easy to use.

## How Does it Work?

As long as the database is idle and there are no requests to serve, everything is kept encrypted in the data files.

Once a request is made, RavenDB will start a transaction (either read or write) and decrypt just the necessary data into memory. Then it will serve the request, and when the transaction is finished, modified pages are encrypted and written back to the datafile.

{DANGER: Important things to be aware of:}
1. RavenDB makes sure that **no data is written to disk as plain text**. It will always be encrypted.  
2. Indexed fields (the actual data) will reside in memory as plain text.  
3. Data of the current transaction will reside in memory as plain text and only for the duration of the transaction. When the transaction ends, the used memory is safely zeroed.  
4. Loading documents from the database (using the Studio, the Client API, REST API) means that they will be decrypted to plain text on the server and then sent to the client (securely) by HTTPS. Once the data is received on the client side it is no longer encrypted. RavenDB does not provide encryption on the client side.
{DANGER/}

{NOTE Due to the overhead of the encryption algorithm, performance can be slightly decreased. However, it doesn't affect the ACID properties of RavenDB which remains both transactional and secure./}

## Locking Memory

RavenDB uses memory-mapped files to keep its data. During normal operations, a process's memory regions may be paged by the OS to a file on disk when RAM has become scarce.

With encrypted databases, we must ensure that plaintext is never written to disk. 
Most of the memory-mapped files used by RavenDB are always encrypted so even if the OS decides to page out a part of a file, it will be written to disk encrypted.

However, the memory-mapped files used for **special temporary buffers** (compression, recovery, etc.) are the exception and are not encrypted since they only reside in memory.  
We lock the memory regions used by these buffers in order to avoid leaking secrets to disk. This means that if we run out of memory, the OS is not allowed to page these buffers to disk. 

The downside to this approach is that if we run out of physical RAM RavenDB won't be able to lock memory and will abort the current operation.
You can change this behavior but it's not recommended and should be done only after a proper security analysis is performed, see the [Security Configuration Section](../../../server/configuration/security-configuration#security.donotconsidermemorylockfailureascatastrophicerror).

If such a catastrophic error occurs in **Windows**, RavenDB will try to recover automatically by increasing the size of the minimum working set and retrying the operation.   
In **Linux**, it is the admin's responsibility to configure higher limits manually using:
{CODE-BLOCK:plain}
sudo prlimit --pid [process-id] --memlock=[new-limit-in-bytes]
{CODE-BLOCK/}

To figure out what the new limit should be, look at the exception thrown by RavenDB, which includes this size.

## What about Encryption in Transit?

To enable encryption in RavenDB, the user must first [enable authentication](../../../server/security/authentication/certificate-configuration) and HTTPS (by providing a certificate).

Enabling Authentication and HTTPS (using the TLS 1.2 protocol) provides privacy and integrity of the data in transit. It protects against man-in-the-middle attacks, eavesdropping, and tampering of the communication.

Using the encryption feature together with HTTPS provides assurance that your data is safe both at rest and in transit.

## Related Articles

### Encryption

- [Database Encryption](../../../server/security/encryption/database-encryption)
- [Server Store Encryption](../../../server/security/encryption/server-store-encryption)
- [Secret Key Management](../../../server/security/encryption/secret-key-management)

### Security

- [Overview](../../../server/security/overview)
