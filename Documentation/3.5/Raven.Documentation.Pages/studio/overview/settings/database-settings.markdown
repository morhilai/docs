# Settings: Database Settings

Here you can edit settings for the current database.

![Figure 1. Settings. Database Settings.](images/settings-database_settings-1.png)

{DANGER Direct edition of the database settings is possible, yet it is not recommended nor supported. Meddling with the database settings document could cause irreversible damage. Any attempts to introduce changes are made at your own risk. /}

###Active bundles protection

There is one exception in possibility to change the database settings (even if you do on your own risk). The setting `Raven/ActiveBundles` is especially protected and cannot be changed
just by editing the database settings document. An attempt to do that will result in throwing `OperationVetoedException`. However if you really need to change the active bundles you must
explicitly mark that by adding `Raven-Temp-Allow-Bundles-Change : true` to the metadata.
