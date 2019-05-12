# Glossary: IndexChangeNotification

### General

This class extends `EventArgs`.

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **Type** | [IndexChangeTypes](../glossary/index-change-notification#indexchangetypes-enum-flags) | Change type |
| **Name** | string | Index name |
| **Etag** | Etag | Index Etag |

<hr />

# IndexChangeTypes (enum flags)

### Members

| Name | Value |
| ---- | ----- |
| **None** | `0` |
| **MapCompleted** | `1` |
| **ReduceCompleted** | `2` |
| **RemoveFromIndex** | `4` |
| **IndexAdded** | `8` |
| **IndexRemoved** | `16` |
| **IndexDemotedToIdle** | `32` |
| **IndexPromotedFromIdle** | `64` |
| **IndexDemotedToAbandoned** | `128` |
| **IndexDemotedToDisabled** | `256` |
| **IndexMarkedAsErrored** | `512` |

