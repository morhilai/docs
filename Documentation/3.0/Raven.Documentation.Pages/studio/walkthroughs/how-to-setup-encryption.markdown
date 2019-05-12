# Walkthroughs: Setting up encryption

To set up an [Encryption](../../server/bundles/encryption) bundle using Studio following steps need to be taken:

Step 1. Create new database (e.g. `Encrypted-Northwind`) with `Encryption` enabled.

![Figure 1. Studio. Encryption. Create database.](images/encryption-1.png)  

Step 2. Configure encryption.

![Figure 2. Studio. Encryption. Configure.](images/encryption-2.png)  

- `Select Key` - your encryption key. **DO NOT LOOSE IT!**
- `Encryption Algorithm` - algorithm that will be used to encrypt your data
	- `DES`
	- `RC2`
	- `Rijndael` (default)
	- `Triple DESC`
- `Encryption Key Bits`
	- `128`
	- `192`
	- `256` (default)
- `Indexes` - indicates if indexing data should be encrypted or not
	- `Encrypt` (default)
	- `Unencrypt`

Step 3. Save Your Encryption Key.

![Figure 2. Studio. Encryption. Save Encryption Key.](images/encryption-3.png)  
