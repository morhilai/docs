# Bundle: Quotas

The Quotas Bundle is helpful when you want to restrict the size of a database. By setting a hard limit and a soft margin, the bundle will make sure you never exceed the space you designate for it to use.

The database size is calculated based on the Esent or Voron data files (excluding the logs), plus the space the indexes are taking on a disk.

Once the hard limit has been reached, no additional documents will be let in the document store. However, indexing operations _will_ resume normal operation, even if it means that the database size will go way over the hard limit. It is so by design, to make sure that the database is fully operational, even when the hard limit has been reached.

A soft limit is defined by the hard-limit minus the soft-limit margin, both are configurable. The first time the soft limit is reached, a warning  under `Raven/WarningMessages` with the `Size Quota` prefix appears.

## Installation

To activate compression server-wide, simply add the `Quotas` to the `Raven/ActiveBundles` configuration in the global configuration file, or setup a new database with a compression bundle turned on using API or the Studio.

To learn how to create a database with quotas enabled using the Studio click [here](../../studio/overview/settings/quotas).

## Configuration

Configure the following values by adding entries to your [server configuration](../../server/configuration/configuration-options) or [database settings](../../server/administration/multiple-databases):

* **Raven/Quotas/Size/HardLimitInKB**
	The hard limit after which we refuse any additional writes.   
	_Default:_ none

* **Raven/Quotas/Size/SoftMarginInKB**
	The soft limit before which we will warn about the quota.   
	_Default:_ 1024

* **Raven/Quotas/Documents/HardLimit**
	The hard limit after which we refuse any additional documents.   
	_Default:_ Int64.MaxValue

* **Raven/Quotas/Documents/SoftLimit**
	The soft limit before which we will warn about the document limit quota.   
	_Default:_ Int64.MaxValue
