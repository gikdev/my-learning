# \MenusApi

All URIs are relative to *http://localhost:5482*

Method | HTTP request | Description
------------- | ------------- | -------------
[**create_menu**](MenusApi.md#create_menu) | **POST** /api/menus | Create new menu
[**delete_menu_by_id**](MenusApi.md#delete_menu_by_id) | **DELETE** /api/menus/{menuId} | Delete a menu by ID
[**duplicate_menu_by_id**](MenusApi.md#duplicate_menu_by_id) | **POST** /api/menus/{menuId}/duplicates | Duplicate a menu by ID
[**list_menus**](MenusApi.md#list_menus) | **GET** /api/menus | List menus
[**update_menu_by_id**](MenusApi.md#update_menu_by_id) | **PUT** /api/menus/{menuId} | Update a menu by ID



## create_menu

> models::MenuItselfResponse create_menu(create_menu_request)
Create new menu

### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**create_menu_request** | [**CreateMenuRequest**](CreateMenuRequest.md) |  | [required] |

### Return type

[**models::MenuItselfResponse**](MenuItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


## delete_menu_by_id

> delete_menu_by_id(menu_id)
Delete a menu by ID

### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**menu_id** | **uuid::Uuid** |  | [required] |

### Return type

 (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


## duplicate_menu_by_id

> models::MenuItselfResponse duplicate_menu_by_id(menu_id)
Duplicate a menu by ID

### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**menu_id** | **uuid::Uuid** |  | [required] |

### Return type

[**models::MenuItselfResponse**](MenuItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


## list_menus

> models::MenuListResponse list_menus()
List menus

### Parameters

This endpoint does not need any parameter.

### Return type

[**models::MenuListResponse**](MenuListResponse.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


## update_menu_by_id

> update_menu_by_id(menu_id, update_menu_request)
Update a menu by ID

### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**menu_id** | **uuid::Uuid** |  | [required] |
**update_menu_request** | [**UpdateMenuRequest**](UpdateMenuRequest.md) |  | [required] |

### Return type

 (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

