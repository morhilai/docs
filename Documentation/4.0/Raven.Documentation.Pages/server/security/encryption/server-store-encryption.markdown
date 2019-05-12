# Encryption: Server Store Encryption

The Server Store is an internal special database (sometimes called the `System` database) which is **not encrypted by default**. 
It is used by RavenDB to hold server wide information and includes details such as the cluster state machine, database records, 
compare-exchange values, client certificate definitions (without the private key), etc.

In particular, the Server Store holds the encryption keys of all the encrypted databases on this server. The encryption
keys are stored encrypted and the admin has the choice of how that encryption would be handled. 
See [Secret Key Management](../../../server/security/encryption/secret-key-management) for more details on this topic.

## Enabling Server Store Encryption

This is an offline operation which should be performed only once using the [rvn tool](../../../server/administration/cli). 
It is recommended to do this at the very start, as part of the initial cluster setup, right after the server was launched for the first time.
Server Store encryption is also possible at later times, even after creating databases and storing documents.

To encrypt the Server Store, make sure the server is not running. Then navigate to the RavenDB application folder where you can find the `rvn` tool. 
Run the following command and supply the path of the `System` folder:

{CODE-BLOCK:bash}
./rvn offline-operation encrypt <path-to-system-dir>
{CODE-BLOCK/}

This operation encrypts the data and saves the encryption key to the same directory.
**The key file (secret.key.encrypted) is protected using RavenDB's secret protection policy**. Read about 
[Secret Key Management](../../../server/security/encryption/secret-key-management) to learn about secret protection in RavenDB.
Once encrypted, The server will only work for the current OS user or the current Master Key (whichever method was chosen to protect secrets). 
Snapshots of an encrypted Server Store can only be restored by the same OS user or the same Master Key which was used during snapshot backup.

From this point on, the Server Store is encrypted and adheres to the same principles of database encryption described 
[here](../../../server/security/encryption/encryption-at-rest#how-does-it-work). You still need to explicitly setup each database as encrypted
and each database will use a different encryption key. In order to restore snapshot backups you'll have to store the encryption key for each
database in a safe location.

## Disabling Server Store Encryption

To decrypt the Server Store, make sure the server is not running. Then navigate to the RavenDB application folder where you can find the `rvn` tool. 
Run the following command and supply the path of the `System` folder:

{CODE-BLOCK:bash}
./rvn offline-operation decrypt <path-to-system-dir>
{CODE-BLOCK/}

The decryption is done using the key file (secret.key.encrypted) which was originally created when the Server Store encryption was enabled.
From this point on, the Server Store is not encrypted anymore and the key file is deleted.

## Backup and Restore an Encrypted Server Store

Because of RavenDB's Secret Protection, the encrypted data is tied to a specific machine/user or to a supplied master key. 
The following instructions **assume that no changes were made** to the OS user or the master key between backup and restore. 
If any of them changed, move to the next section.

Navigate to the RavenDB application folder where you can find the `rvn` tool. Run the following command and supply the path of the `System` folder:

{CODE-BLOCK:bash}
./rvn offline-operation get-key <path-to-system-dir>
{CODE-BLOCK/}

The output is the plaintext key which is not protected and not tied to any user or master key. This key allows you to move the snapshot to any environment. 
Save the `System` folder in a safe place. This is your snapshot backup. If you decide to separate the key file from the backup data (recommended) you should 
make sure to return the key file to the folder before performing a restore.

To restore a Server Store from the snapshot backup, first shutdown the server. 
Delete the current `System` folder and replace it with the backed up folder (don't forget to rename it to `System`).
Then restart the server.

## Moving the encrypted Server Store to a new machine or a different OS user

Because of RavenDB's Secret Protection, the encrypted data is tied to a specific machine/user or to a supplied master key. 
Moving the server to a new machine or switching the OS user requires the admin to perform an additional offline operation.

Navigate to the RavenDB application folder where you can find the `rvn` tool. Run the following command and supply the path of the `System` folder:

{CODE-BLOCK:bash}
./rvn offline-operation get-key <path-to-system-dir>
{CODE-BLOCK/}

The output is the plaintext key which is not protected and not tied to any user or master key. This key allows you to move the snapshot to any environment. 


On the new machine, copy the `System` folder to the new location. 
run the following command and supply the path of the `System` folder and the key you just got (using get-key):

{CODE-BLOCK:bash}
./rvn offline-operation put-key <path-to-system-dir> <base64-plaintext-key>
{CODE-BLOCK/}

This operation takes the key and protects it for the new OS user or new master key. 
The protected key is then saved as a file in the same folder (secret.key.encrypted).
Now, you can run the server, which will use this new protected key and you can work with the restored data.

## Related Articles

### Encryption

- [Encryption at Rest](../../../server/security/encryption/encryption-at-rest)
- [Database Encryption](../../../server/security/encryption/database-encryption)
- [Secret Key Management](../../../server/security/encryption/secret-key-management)

### Security

- [Overview](../../../server/security/overview)
