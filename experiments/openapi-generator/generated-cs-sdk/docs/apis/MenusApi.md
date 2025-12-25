# ImsApiSdk.Api.MenusApi

All URIs are relative to *http://localhost:5482*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateMenu**](MenusApi.md#createmenu) | **POST** /api/menus | Create new menu |
| [**DeleteMenuById**](MenusApi.md#deletemenubyid) | **DELETE** /api/menus/{menuId} | Delete a menu by ID |
| [**DuplicateMenuById**](MenusApi.md#duplicatemenubyid) | **POST** /api/menus/{menuId}/duplicates | Duplicate a menu by ID |
| [**ListMenus**](MenusApi.md#listmenus) | **GET** /api/menus | List menus |
| [**UpdateMenuById**](MenusApi.md#updatemenubyid) | **PUT** /api/menus/{menuId} | Update a menu by ID |

<a id="createmenu"></a>
# **CreateMenu**
> MenuItselfResponse CreateMenu (CreateMenuRequest createMenuRequest)

Create new menu


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createMenuRequest** | [**CreateMenuRequest**](CreateMenuRequest.md) |  |  |

### Return type

[**MenuItselfResponse**](MenuItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deletemenubyid"></a>
# **DeleteMenuById**
> void DeleteMenuById (Guid menuId)

Delete a menu by ID


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **menuId** | **Guid** |  |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="duplicatemenubyid"></a>
# **DuplicateMenuById**
> MenuItselfResponse DuplicateMenuById (Guid menuId)

Duplicate a menu by ID


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **menuId** | **Guid** |  |  |

### Return type

[**MenuItselfResponse**](MenuItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="listmenus"></a>
# **ListMenus**
> MenuListResponse ListMenus ()

List menus


### Parameters
This endpoint does not need any parameter.
### Return type

[**MenuListResponse**](MenuListResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="updatemenubyid"></a>
# **UpdateMenuById**
> void UpdateMenuById (Guid menuId, UpdateMenuRequest updateMenuRequest)

Update a menu by ID


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **menuId** | **Guid** |  |  |
| **updateMenuRequest** | [**UpdateMenuRequest**](UpdateMenuRequest.md) |  |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

