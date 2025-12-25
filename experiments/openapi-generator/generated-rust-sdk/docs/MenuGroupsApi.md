# \MenuGroupsApi

All URIs are relative to *http://localhost:5482*

Method | HTTP request | Description
------------- | ------------- | -------------
[**create_menu_group**](MenuGroupsApi.md#create_menu_group) | **POST** /api/menus/{menuId}/tabs/{menuTabId}/groups | Create new menu group



## create_menu_group

> models::MenuGroupItselfResponse create_menu_group(menu_id, menu_tab_id, create_menu_group_request)
Create new menu group

### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**menu_id** | **uuid::Uuid** |  | [required] |
**menu_tab_id** | **uuid::Uuid** |  | [required] |
**create_menu_group_request** | [**CreateMenuGroupRequest**](CreateMenuGroupRequest.md) |  | [required] |

### Return type

[**models::MenuGroupItselfResponse**](MenuGroupItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

