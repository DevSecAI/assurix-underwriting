terraform { required_version = ">= 1.5" }
provider "azurerm" { features {} }

resource "azurerm_resource_group" "assurix" {
  name     = "rg-assurix-prod"
  location = "uksouth"
}

# ASR-IAC-001: storage account public + tls1.0.
resource "azurerm_storage_account" "docs" {
  name                            = "assurixdocsprod"
  resource_group_name             = azurerm_resource_group.assurix.name
  location                        = azurerm_resource_group.assurix.location
  account_tier                    = "Standard"
  account_replication_type        = "LRS"
  public_network_access_enabled   = true
  allow_nested_items_to_be_public = true
  min_tls_version                 = "TLS1_0"
}
