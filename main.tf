# Configure the Azure provider
terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 4.62.1"
    }
  }

  required_version = ">= 1.1.0"
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "discounts_rg" {
  name     = "discounts-salling-resource-group"
  location = "westeurope"
}

resource "azurerm_service_plan" "discounts_sp" {
  name                = "discounts-salling-service-plan"
  resource_group_name = azurerm_resource_group.discounts_rg.name
  location            = azurerm_resource_group.discounts_rg.location
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "discounts_api" {
  name                = "discounts-salling-api"
  resource_group_name = azurerm_resource_group.discounts_rg.name
  location            = azurerm_service_plan.discounts_sp.location
  service_plan_id     = azurerm_service_plan.discounts_sp.id

  site_config {
    always_on = false
  }
}