# Troubleshooting: Voron Recovery Tool

The Voron recovery tool is designed to extract your data even on the worst corruption state imaginable.  

{PANEL: How to run it}

For Windows, the syntax to run will be:  
{CODE-BLOCK:powershell}  
Voron.Recovery.exe recover <Voron data-file directory> <Recovery directory>  
{CODE-BLOCK/}  

For Linux, the syntax to run will be:  
{CODE-BLOCK:powershell}
dotnet ./Voron.Recovery.dll recover <Voron data-file directory> <Recovery directory>  
{CODE-BLOCK/}

The process may take some time to run, depending on the storage speed and the recovered database size.  

* The tool will create: 
  * **recovery-2-Documents.ravendump**, an export file containing all documents and attachments.
  * **recovery-3-Revisions.ravendump**, an export file containing revisioned documents.
  * **recovery-4-Conflicts.ravendump**, an export file containing conflicted documents.
  * If the log is enabled a final report containing information about the amount of recovered and faulty data will be produced  
    For detailed information invoke the tool with `--LoggingMode Information`  
    For summery and errors invoke the tool with `--LoggingMode Operations`  

All the files above have the standard RavenDB export format and can be imported to RavenDB.  
Recovery-1- was removed and is reserved for later use.  

{NOTE: Note}

* Recovery of encrypted data files is not supported at the moment  
* The export may contain deleted documents/attachments since they still reside in the file and we can not automatically tell the latest version (under the assumption that the file is corrupted).

{NOTE/}

{PANEL/}

{PANEL: Additional flags}

`--OutputFileName`: overwrite the default output file name  

`--PageSizeInKB`: overwrite the expected Voron page size of 8KB. It should never be used unless told by the support team.  

`--InitialContextSizeInMB`: overwrite the starting size of memory used by the recovery tool, the default is 4KByte.  

`--InitialContextLongLivedSizeInKB`: overwrite the starting size of memory used by the recovery tool for long-lived objects, the default is 4KByte.  

`--ProgressIntervalInSec`: overwrite the time interval in which the recovery tool refreshes the report in the console.  

`--DisableCopyOnWriteMode`: disables the copy on write. This option should be used when recovering the journals failed, which would happen most likely due to them being corrupted. In this case, the error indicating corruption of journals will be thrown by the Voron engine, and this will stop the recovery process.  
{NOTE The data-file should be backed up before using this option. /}  

`--LoggingMode`: controls the logging level, either `Operations` or `Information` are valid values.  
{NOTE Logging is not enabled by default, for any output report, the tool should be invoked with this option. /}  

{PANEL/}

