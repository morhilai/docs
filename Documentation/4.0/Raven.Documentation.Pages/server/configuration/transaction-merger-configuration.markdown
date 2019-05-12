# Configuration: Transaction Merger Options

{PANEL:TransactionMerger.MaxTimeToWaitForPreviousTxInMs}

EXPERT: Time to wait (in milliseconds) for the previous async commit before checking for the tx size.

- **Type**: `int`
- **Default**: `0`
- **Scope**: Server-wide or per database

{PANEL/}

{PANEL:TransactionMerger.MaxTimeToWaitForPreviousTxBeforeRejectingInMs}

EXPERT: Time to wait for the previous async commit transaction before rejecting the request due to long duration IO.

- **Type**: `int`
- **Default**: `5000`
- **Scope**: Server-wide or per database

{PANEL/}

{PANEL:TransactionMerger.MaxTxSizeInMb}

EXPERT: Maximum size (in MB) for the merged transaction.

- **Type**: `int`
- **Default**: 4MB for 32-bit or minimum of either `10% of total physical memory` or `512` for 64-bit
- **Scope**: Server-wide or per database

{PANEL/}
