Note: where `/database/*/` prefix exists, replace `*` with database name					
# Debug					
|Endpoint 	|Method 	|Parameters 	|Description 	|Remarks	|*|
|-|-|-|-|-|-|
|/admin/debug/cluster-info-package	|GET	|	|Returns whole cluster information package as zip format| ||
|/admin/debug/cpu/stats	|GET	|	|Returns RavenDB's processor usage and thread pool status	|	||
|/admin/debug/info-package	|GET	|	|Save debug package information for later analysis	|	||
|/admin/debug/memory/low-mem-log	|GET	|	|Low memory events report	|	||
|/admin/debug/memory/smaps	|GET	|	|Returns all RavenDB's process mappings including shared/private clean/dirty memory allocations	|Availabe only on Linux	||
|/admin/debug/memory/stats	|GET	|	|Full report of memory usage including un/managed usage by thread and free memory status 	|	||
|/admin/debug/node/engine-logs	|GET	|	|Rachis logs	|	||
|/admin/debug/node/ping	|GET	|-(Optional) url-<br /> -(Optional)node-<br />For specifying the node by url or node tag 	|Test the ability to reach the server | ||
|/admin/debug/node/remote-connections	|GET	|	|Returns connections' detailes of members and whacher in the cluster |  ||
|/admin/debug/node/state-change-history	|GET	|	|List the node's state transition history in the cluster	|	||
|/admin/debug/proc/meminfo	|GET	|	|Return /proc/<RavenDB ProcNum>/meminfo	|Availabe only on Linux	||
|/admin/debug/proc/stats	|GET	|	|Return /proc/<RavenDB ProcNum>/stats	|Availabe only on Linux	||
|/admin/debug/proc/status	|GET	|	|Return /proc/<RavenDB ProcNum>/status	|Availabe only on Linux	||
|/admin/debug/threads/runaway	|GET	|	|List all threads and their names, sorted by duration	|	||
|/build/version	|GET	|	|Returns product build number, major version, commit hash and full version number	|	||
|/databases/*/admin/debug/cluster/txinfo	|GET	|-(Optional) from - Amount of result to skip<br /> -(Optional)take - Amount of result to take|List the incomplete [cluster transaction commands](../clustering/cluster-transactions#cluster--cluster-wide-transactions) |	||
|/databases/*/admin/debug/txinfo	|GET	|	|List 	|	||
|/databases/*/debug/documents/huge	|GET	|	|List documents IDs which exceeds PerformanceHints.Documents.HugeDocumentSizeInMb settings	|	||
|/databases/*/debug/identities	|GET	|	|	|	|TODO|
|/databases/*/debug/info-package	|GET	|	|Save debug package information for later analysis	|	||
|/databases/*/debug/io-metrics	|GET	|	|Get current IO metrics: "Writes, Flush, Sync" for each storage environment	|	||
|/databases/*/debug/perf-metrics	|GET	|	|Get current IO metrics: "Transactions" for each storage environment	|	||
|/databases/*/debug/queries/cache/list	|GET	|	|	|	||
|/databases/*/debug/queries/running	|GET	|	|	|	||
|/databases/*/debug/script-runners	|GET	|	|	|	||
|/databases/*/debug/storage/all-environments/report	|GET	|	|	|	||
|/databases/*/debug/storage/report	|GET	|	|	|	||
|/databases/*/indexes	|GET	|	|	|	||
|/databases/*/indexes/errors	|GET	|	|	|	||
|/databases/*/indexes/stats	|GET	|	|	|	||
|/databases/*/replication/debug/incoming-last-activity-time	|GET	|	|	|	||
|/databases/*/replication/debug/incoming-rejection-info	|GET	|	|	|	||
|/databases/*/replication/debug/outgoing-failures	|GET	|	|	|	||
|/databases/*/replication/debug/outgoing-reconnect-queue	|GET	|	|	|	||
|/databases/*/stats	|GET	|	|	|	||
|/debug/server-id	|GET	|	|	|	||

# Production

|/	|GET	|	|	|	||
|/admin/certificates	|POST, PUT, DELETE, GET	|	|	|	||
|/admin/certificates/cluster-domains	|GET	|	|	|	||
|/admin/certificates/edit	|POST	|	|	|	||
|/admin/certificates/export	|GET	|	|	|	||
|/admin/certificates/letsencrypt/force-renew	|OPTIONS, POST	|	|	|	||
|/admin/certificates/letsencrypt/renewal-date	|GET	|	|	|	||
|/admin/certificates/mode	|GET	|	|	|	||
|/admin/certificates/refresh	|OPTIONS, POST	|	|	|	||
|/admin/certificates/replace-cluster-cert	|OPTIONS, POST	|	|	|	||
|/admin/certificates/replacement/reset	|POST	|	|	|	||
|/admin/certificates/replacement/status	|GET	|	|	|	||
|/admin/cluster/bootstrap	|POST	|	|	|	||
|/admin/cluster/demote	|OPTIONS, POST	|	|	|	||
|/admin/cluster/log	|GET	|	|	|	||
|/admin/cluster/maintenance-stats	|GET	|	|	|	||
|/admin/cluster/node	|OPTIONS, PUT, DELETE	|	|	|	||
|/admin/cluster/observer/decisions	|GET, OPTIONS	|	|	|	||
|/admin/cluster/observer/suspend	|POST, OPTIONS	|	|	|	||
|/admin/cluster/promote	|OPTIONS, POST	|	|	|	||
|/admin/cluster/reelect	|OPTIONS, POST	|	|	|	||
|/admin/cluster/timeout	|OPTIONS, POST	|	|	|	||
|/admin/compact	|POST	|	|	|	||
|/admin/configuration/client	|PUT	|	|	|	||
|/admin/configuration/studio	|PUT	|	|	|	||
|/admin/console	|POST	|	|	|	||
|/admin/databases	|GET, PUT, DELETE	|	|	|	||
|/admin/databases/disable	|POST	|	|	|	||
|/admin/databases/dynamic-node-distribution	|POST	|	|	|	||
|/admin/databases/enable	|POST	|	|	|	||
|/admin/databases/node	|PUT	|	|	|	||
|/admin/databases/promote	|POST	|	|	|	||
|/admin/databases/reorder	|POST	|	|	|	||
|/admin/debug/remote-cluster-info-package	|GET	|	|	|	||
|/admin/debug/script-runners	|GET	|	|	|	||
|/admin/license/activate	|POST	|	|	|	||
|/admin/license/eula/accept	|POST	|	|	|	||
|/admin/license/forceUpdate	|POST	|	|	|	||
|/admin/license/set-limit	|OPTIONS, POST	|	|	|	||
|/admin/logs/configuration	|GET, POST	|	|	|	||
|/admin/logs/watch	|GET	|	|	|	||
|/admin/memory/gc	|GET	|	|	|	||
|/admin/metrics	|GET	|	|	|	||
|/admin/migrate	|POST	|	|	|	||
|/admin/migrate/offline	|POST	|	|	|	||
|/admin/operations/kill	|POST	|	|	|	||
|/admin/operations/next-operation-id	|GET	|	|	|	||
|/admin/rachis/send	|POST	|	|	|	||
|/admin/remote-server/build/version	|GET	|	|	|	||
|/admin/replication/conflicts/solver	|POST	|	|	|	||
|/admin/restore/database	|POST	|	|	|	||
|/admin/restore/points	|POST	|	|	|	||
|/admin/secrets	|GET, POST	|	|	|	||
|/admin/secrets/distribute	|POST	|	|	|	||
|/admin/secrets/generate	|GET	|	|	|	||
|/admin/studio-tasks/full-data-directory	|GET	|	|	|	||
|/admin/studio-tasks/offline-migration-test	|GET	|	|	|	||
|/admin/test-connection	|POST	|	|	|	||
|/admin/traffic-watch	|GET	|	|	|	||
|/auth-error.html	|GET	|	|	|	||
|/build/version/updates	|POST	|	|	|	||
|/certificates/whoami	|GET	|	|	|	||
|/cluster/node-info	|GET	|	|	|	||
|/cluster/topology	|GET	|	|	|	||
|/configuration/client	|GET	|	|	|	||
|/configuration/studio	|GET	|	|	|	||
|/databases	|GET	|	|	|	||
|/databases/*/admin/backup/database	|OPTIONS, POST	|	|	|	||
|/databases/*/admin/configuration/client	|PUT	|	|	|	||
|/databases/*/admin/configuration/studio	|PUT	|	|	|	||
|/databases/*/admin/connection-strings	|DELETE, GET, PUT	|	|	|	||
|/databases/*/admin/etl	|RESET, PUT	|	|	|	||
|/databases/*/admin/etl/raven/test	|POST	|	|	|	||
|/databases/*/admin/etl/sql/test	|POST	|	|	|	||
|/databases/*/admin/etl/sql/test-connection	|POST	|	|	|	||
|/databases/*/admin/expiration/config	|POST	|	|	|	||
|/databases/*/admin/indexes	|PUT	|	|	|	||
|/databases/*/admin/indexes/disable	|POST	|	|	|	||
|/databases/*/admin/indexes/enable	|POST	|	|	|	||
|/databases/*/admin/indexes/start	|POST	|	|	|	||
|/databases/*/admin/indexes/stop	|POST	|	|	|	||
|/databases/*/admin/periodic-backup	|POST	|	|	|	||
|/databases/*/admin/periodic-backup/config	|GET	|	|	|	||
|/databases/*/admin/periodic-backup/test-credentials	|POST	|	|	|	||
|/databases/*/admin/revisions	|DELETE	|	|	|	||
|/databases/*/admin/revisions/config	|POST	|	|	|	||
|/databases/*/admin/smuggler/import	|GET	|	|	|	||
|/databases/*/admin/smuggler/import-dir	|GET	|	|	|	||
|/databases/*/admin/smuggler/import-s3-dir	|GET	|	|	|	||
|/databases/*/admin/smuggler/migrate	|POST	|	|	|	||
|/databases/*/admin/smuggler/migrate/ravendb	|POST	|	|	|	||
|/databases/*/admin/sql-migration/import	|POST	|	|	|	||
|/databases/*/admin/sql-migration/schema	|POST	|	|	|	||
|/databases/*/admin/sql-migration/test	|POST	|	|	|	||
|/databases/*/admin/tasks	|DELETE	|	|	|	||
|/databases/*/admin/tasks/external-replication	|POST	|	|	|	||
|/databases/*/admin/tasks/state	|POST	|	|	|	||
|/databases/*/admin/transactions-mode	|GET	|	|	|	||
|/databases/*/admin/transactions/start-recording	|POST	|	|	|	||
|/databases/*/admin/transactions/stop-recording	|POST	|	|	|	||
|/databases/*/attachments	|HEAD, GET, POST, PUT, DELETE	|	|	|	||
|/databases/*/bulk_docs	|POST	|	|	|	||
|/databases/*/bulk_insert	|POST	|	|	|	||
|/databases/*/changes	|GET, DELETE	|	|	|	||
|/databases/*/changes/debug	|GET	|	|	|	||
|/databases/*/cmpxchg	|GET, PUT, DELETE	|	|	|	||
|/databases/*/collections/docs	|GET	|	|	|	||
|/databases/*/collections/stats	|GET	|	|	|	||
|/databases/*/configuration/client	|GET	|	|	|	||
|/databases/*/configuration/studio	|GET	|	|	|	||
|/databases/*/counters	|GET, POST	|	|	|	||
|/databases/*/debug/attachments/hash	|GET	|	|	|	||
|/databases/*/debug/attachments/metadata	|GET	|	|	|	||
|/databases/*/debug/documents/export-all-ids	|GET	|	|	|	||
|/databases/*/debug/documents/get-revisions	|GET	|	|	|	||
|/databases/*/debug/io-metrics/live	|GET	|	|	|	||
|/databases/*/debug/queries/kill	|POST	|	|	|	||
|/databases/*/debug/storage/btree-structure	|GET	|	|	|	||
|/databases/*/debug/storage/environment/report	|GET	|	|	|	||
|/databases/*/debug/storage/fst-structure	|GET	|	|	|	||
|/databases/*/docs	|HEAD, GET, POST, DELETE, PUT, PATCH	|	|	|	||
|/databases/*/docs/class	|GET	|	|	|	||
|/databases/*/docs/size	|GET	|	|	|	||
|/databases/*/etl/debug/stats	|GET	|	|	|	||
|/databases/*/etl/performance	|GET	|	|	|	||
|/databases/*/etl/stats	|GET	|	|	|	||
|/databases/*/expiration/config	|GET	|	|	|	||
|/databases/*/hilo/next	|GET	|	|	|	||
|/databases/*/hilo/return	|PUT	|	|	|	||
|/databases/*/identity/next	|POST	|	|	|	||
|/databases/*/identity/seed	|POST	|	|	|	||
|/databases/*/index/open-faulty-index	|POST	|	|	|	||
|/databases/*/indexes	|RESET, DELETE, PUT	|	|	|	||
|/databases/*/indexes/c-sharp-index-definition	|GET	|	|	|	||
|/databases/*/indexes/debug	|GET	|	|	|	||
|/databases/*/indexes/has-changed	|POST	|	|	|	||
|/databases/*/indexes/performance	|GET	|	|	|	||
|/databases/*/indexes/performance/live	|GET	|	|	|	||
|/databases/*/indexes/progress	|GET	|	|	|	||
|/databases/*/indexes/replace	|POST	|	|	|	||
|/databases/*/indexes/set-lock	|POST	|	|	|	||
|/databases/*/indexes/set-priority	|POST	|	|	|	||
|/databases/*/indexes/source	|GET	|	|	|	||
|/databases/*/indexes/staleness	|GET	|	|	|	||
|/databases/*/indexes/status	|GET	|	|	|	||
|/databases/*/indexes/suggest-index-merge	|GET	|	|	|	||
|/databases/*/indexes/terms	|GET	|	|	|	||
|/databases/*/indexes/total-time	|GET	|	|	|	||
|/databases/*/indexes/try	|POST	|	|	|	||
|/databases/*/info/tcp	|GET	|	|	|	||
|/databases/*/metrics	|GET	|	|	|	||
|/databases/*/metrics/bytes	|GET	|	|	|	||
|/databases/*/metrics/puts	|GET	|	|	|	||
|/databases/*/migrate/get-migrated-server-urls	|GET	|	|	|	||
|/databases/*/multi_get	|POST	|	|	|	||
|/databases/*/notification-center/dismiss	|POST	|	|	|	||
|/databases/*/notification-center/postpone	|POST	|	|	|	||
|/databases/*/notification-center/watch	|GET	|	|	|	||
|/databases/*/operations	|GET	|	|	|	||
|/databases/*/operations/kill	|POST	|	|	|	||
|/databases/*/operations/next-operation-id	|GET	|	|	|	||
|/databases/*/operations/state	|GET	|	|	|	||
|/databases/*/queries	|POST, GET, DELETE, PATCH	|	|	|	||
|/databases/*/queries/test	|PATCH	|	|	|	||
|/databases/*/replication/active-connections	|GET	|	|	|	||
|/databases/*/replication/conflicts	|GET	|	|	|	||
|/databases/*/replication/conflicts/solver	|GET	|	|	|	||
|/databases/*/replication/performance	|GET	|	|	|	||
|/databases/*/replication/performance/live	|GET	|	|	|	||
|/databases/*/replication/pulses/live	|GET	|	|	|	||
|/databases/*/replication/tombstones	|GET	|	|	|	||
|/databases/*/revisions	|GET	|	|	|	||
|/databases/*/revisions/bin	|GET	|	|	|	||
|/databases/*/revisions/config	|GET	|	|	|	||
|/databases/*/revisions/resolved	|GET	|	|	|	||
|/databases/*/smuggler/export	|POST	|	|	|	||
|/databases/*/smuggler/import	|POST	|	|	|	||
|/databases/*/smuggler/import/csv	|POST	|	|	|	||
|/databases/*/smuggler/validate-options	|POST	|	|	|	||
|/databases/*/stats/detailed	|GET	|	|	|	||
|/databases/*/streams/docs	|GET	|	|	|	||
|/databases/*/streams/queries	|HEAD, GET, POST	|	|	|	||
|/databases/*/studio-tasks/suggest-conflict-resolution	|GET	|	|	|	||
|/databases/*/studio/collections/docs	|DELETE	|	|	|	||
|/databases/*/studio/collections/fields	|GET	|	|	|	||
|/databases/*/studio/collections/preview	|GET	|	|	|	||
|/databases/*/studio/footer/stats	|GET	|	|	|	||
|/databases/*/studio/index-fields	|POST	|	|	|	||
|/databases/*/studio/index-type	|POST	|	|	|	||
|/databases/*/studio/sample-data	|POST	|	|	|	||
|/databases/*/studio/sample-data/classes	|GET	|	|	|	||
|/databases/*/subscription-tasks	|DELETE	|	|	|	||
|/databases/*/subscription-tasks/state	|POST	|	|	|	||
|/databases/*/subscriptions	|PUT, DELETE, GET	|	|	|	||
|/databases/*/subscriptions/connection-details	|GET	|	|	|	||
|/databases/*/subscriptions/drop	|POST	|	|	|	||
|/databases/*/subscriptions/state	|GET	|	|	|	||
|/databases/*/subscriptions/try	|POST	|	|	|	||
|/databases/*/task	|GET	|	|	|	||
|/databases/*/tasks	|GET	|	|	|	||
|/databases/*/tcp	|GET, DELETE	|	|	|	||
|/databases/*/transactions/replay	|POST	|	|	|	||
|/debug/is-loaded	|GET	|	|	|	||
|/debug/routes	|GET	|	|	|	||
|/eula/$	|GET	|	|	|	||
|/eula/index.html	|GET	|	|	|	||
|/favicon.ico	|GET	|	|	|	||
|/info/tcp	|GET	|	|	|	||
|/license/eula	|GET	|	|	|	||
|/license/status	|GET	|	|	|	||
|/license/support	|GET	|	|	|	||
|/monitoring/snmp	|GET	|	|	|	||
|/monitoring/snmp/oids	|GET	|	|	|	||
|/operations/state	|GET	|	|	|	||
|/periodic-backup	|GET	|	|	|	||
|/periodic-backup/next-backup-occurrence	|GET	|	|	|	||
|/periodic-backup/status	|GET	|	|	|	||
|/rachis/waitfor	|Get	|	|	|	||
|/server-dashboard/watch	|GET	|	|	|	||
|/server/notification-center/dismiss	|POST	|	|	|	||
|/server/notification-center/postpone	|POST	|	|	|	||
|/server/notification-center/watch	|GET	|	|	|	||
|/setup/alive	|OPTIONS, GET	|	|	|	||
|/setup/continue	|POST	|	|	|	||
|/setup/continue/extract	|POST	|	|	|	||
|/setup/dns-n-cert	|POST	|	|	|	||
|/setup/finish	|POST	|	|	|	||
|/setup/hosts	|POST	|	|	|	||
|/setup/ips	|GET	|	|	|	||
|/setup/letsencrypt	|POST	|	|	|	||
|/setup/letsencrypt/agreement	|GET	|	|	|	||
|/setup/parameters	|GET	|	|	|	||
|/setup/populate-ips	|POST	|	|	|	||
|/setup/secured	|POST	|	|	|	||
|/setup/unsecured	|POST	|	|	|	||
|/setup/user-domains	|POST	|	|	|	||
|/studio-tasks/format	|POST	|	|	|	||
|/studio-tasks/is-valid-name	|GET	|	|	|	||
|/studio/$	|GET	|	|	|	||
|/studio/feedback	|POST	|	|	|	||
|/studio/index.html	|GET	|	|	|	||
|/test/delay	|GET	|	|	|	||
|/test/empty-message	|GET	|	|	|	||
|/test/sized-message	|GET	|	|	|	||
|/topology	|GET	|	|	|	||
|/wizard/$	|GET	|	|	|	||
|/wizard/index.html	|GET	|	|	|	||

