# \MenuTabsApi

All URIs are relative to *http://localhost:5482*

Method | HTTP request | Description
------------- | ------------- | -------------
[**create_menu_tab**](MenuTabsApi.md#create_menu_tab) | **POST** /api/menus/{menuId}/tabs | Create new menu tab
[**delete_menu_tab_by_id**](MenuTabsApi.md#delete_menu_tab_by_id) | **DELETE** /api/menus/{menuId}/tabs/{menuTabId} | Delete menu tab by ID
[**list_menu_tabs**](MenuTabsApi.md#list_menu_tabs) | **GET** /api/menus/{menuId}/tabs | List a menu's tabs
[**update_menu_tab_by_id**](MenuTabsApi.md#update_menu_tab_by_id) | **PUT** /api/menus/{menuId}/tabs/{menuTabId} | Update menu tab by ID



## create_menu_tab

> models::MenuTabItselfResponse create_menu_tab(menu_id, create_menu_tab_request)
Create new menu tab

### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**menu_id** | **uuid::Uuid** |  | [required] |
**create_menu_tab_request** | [**CreateMenuTabRequest**](CreateMenuTabRequest.md) |  | [required] |

### Return type

[**models::MenuTabItselfResponse**](MenuTabItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


## delete_menu_tab_by_id

> delete_menu_tab_by_id(menu_id, menu_tab_id)
Delete menu tab by ID

### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**menu_id** | **uuid::Uuid** |  | [required] |
**menu_tab_id** | **uuid::Uuid** |  | [required] |

### Return type

 (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


## list_menu_tabs

> models::MenuTabListResponse list_menu_tabs(menu_id)
List a menu's tabs

### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**menu_id** | **uuid::Uuid** |  | [required] |

### Return type

[**models::MenuTabListResponse**](MenuTabListResponse.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


## update_menu_tab_by_id

> models::MenuTabItselfResponse update_menu_tab_by_id(menu_id, menu_tab_id, update_menu_tab_request)
Update menu tab by ID

### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**menu_id** | **uuid::Uuid** |  | [required] |
**menu_tab_id** | **uuid::Uuid** |  | [required] |
**update_menu_tab_request** | [**UpdateMenuTabRequest**](UpdateMenuTabRequest.md) |  | [required] |

### Return type

[**models::MenuTabItselfResponse**](MenuTabItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

