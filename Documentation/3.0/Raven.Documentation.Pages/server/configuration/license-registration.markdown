# Configuration: License registration

In order to register an instance of RavenDB with a license, you can: 

- rename the license file to License.xml and put it in the bin folder where RavenDB executable ,exists
- use the following configuration options:

	*	 **Raven/License**
	The full license string for RavenDB. If Raven/License is specified, it overrides the Raven/LicensePath configuration.

	*	 **Raven/LicensePath**
	The path to the license file for RavenDB.   
	_Default:_ ~\license.xml

{NOTE Each instance of RavenDB outside of the development machines has to be registered with a license. /}

{DANGER If your server was setup to  allow **unrestricted access to server** (`Raven/AnonymousAccess` set to `Admin`), and you install a license, then you *have* to either set `Raven/AnonymousAccess` to `None` or to set `Raven/Licensing/AllowAdminAnonymousAccessForCommercialUse` to **true**. Failing to do that will result in an error when RavenDB starts, due to invalid configuration. This is to prevent an admin from having a licensed server that was left in its default configuration, open to the world. A licensed RavenDB server *must* either have `Raven/AnonymousAccess` to `None`  or to explicitly specify that you want it to be licensed but allow everyone full access to it.  /}
