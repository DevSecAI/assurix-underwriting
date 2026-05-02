# Assurix — Seeded Findings (23 total)

## SAST (10)
| ID | CWE | File |
|---|---|---|
| ASR-SAST-001 | CWE-89   | `src/Controllers/PoliciesController.cs` (string concat to SqlCommand) |
| ASR-SAST-002 | CWE-502  | `src/Controllers/AdminController.cs` (BinaryFormatter.Deserialize) |
| ASR-SAST-003 | CWE-611  | `src/Services/QuoteImporter.cs` (XmlReader without DTD prohibition) |
| ASR-SAST-004 | CWE-798  | `src/appsettings.json` (DB password, JWT signing key) |
| ASR-SAST-005 | CWE-352  | `src/Program.cs` (CSRF disabled in MVC pipeline) |
| ASR-SAST-006 | CWE-22   | `src/Controllers/DocsController.cs` (Path.Combine on user input) |
| ASR-SAST-007 | CWE-918  | `src/Services/Webhook.cs` (HttpClient.GetAsync on caller URL) |
| ASR-SAST-008 | CWE-327  | `src/Services/Crypto.cs` (TripleDES + ECB) |
| ASR-SAST-009 | CWE-209  | `src/Middleware/Errors.cs` (full exception in body) |
| ASR-SAST-010 | CWE-1004 | `src/Program.cs` (SameSite=None, Secure=false on session cookie) |

## IaC (6)
- ASR-IAC-001 Storage Account public network access (`infra/terraform/storage.tf`)
- ASR-IAC-002 SQL Server `public_network_access_enabled=true` (`infra/terraform/sql.tf`)
- ASR-IAC-003 SQL Server no Azure AD admin (`infra/terraform/sql.tf`)
- ASR-IAC-004 NSG inbound 1433/* (`infra/terraform/network.tf`)
- ASR-IAC-005 Container runs as root (`Dockerfile`)
- ASR-IAC-006 K8s no resource limits + no readOnlyRootFilesystem (`infra/k8s/deployment.yaml`)

## SCA (4)
| ID | Package | Version | CVE |
|---|---|---|---|
| ASR-SCA-001 | Newtonsoft.Json     | 12.0.3 | CVE-2024-21907 |
| ASR-SCA-002 | System.Data.SqlClient | 4.6.0 | CVE-2022-41064 |
| ASR-SCA-003 | Microsoft.AspNetCore.Mvc.NewtonsoftJson | 5.0.0 | dependency chain |
| ASR-SCA-004 | log4net             | 2.0.8  | CVE-2018-1285 |

## Pipeline (3)
- ASR-CI-001 Hardcoded `AZURE_CREDENTIALS` JSON in workflow (`.github/workflows/ci.yml`)
- ASR-CI-002 No `permissions:` block
- ASR-CI-003 NuGet pulls from `http://` private feed
