resource "azurerm_network_security_group" "assurix" {
  name                = "nsg-assurix"
  location            = azurerm_resource_group.assurix.location
  resource_group_name = azurerm_resource_group.assurix.name

  # ASR-IAC-004: NSG ingress on SQL port 1433 from anywhere.
  security_rule {
    name                       = "allow-sql-any"
    priority                   = 100
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "1433"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }
}
