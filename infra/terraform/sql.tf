resource "azurerm_mssql_server" "assurix" {
  name                = "sql-assurix-prod"
  resource_group_name = azurerm_resource_group.assurix.name
  location            = azurerm_resource_group.assurix.location
  version             = "12.0"

  administrator_login          = "sqladmin"
  administrator_login_password = "Assurix2024!"

  # ASR-IAC-002: publicly accessible.
  public_network_access_enabled = true

  # ASR-IAC-003: no `azuread_administrator` block — Azure AD admin not configured.
}

resource "azurerm_mssql_database" "underwriting" {
  name      = "underwriting"
  server_id = azurerm_mssql_server.assurix.id
  sku_name  = "S1"
}
