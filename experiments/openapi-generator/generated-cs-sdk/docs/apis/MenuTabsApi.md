# ImsApiSdk.Api.MenuTabsApi

All URIs are relative to *http://localhost:5482*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateMenuTab**](MenuTabsApi.md#createmenutab) | **POST** /api/menus/{menuId}/tabs | Create new menu tab |
| [**DeleteMenuTabById**](MenuTabsApi.md#deletemenutabbyid) | **DELETE** /api/menus/{menuId}/tabs/{menuTabId} | Delete menu tab by ID |
| [**ListMenuTabs**](MenuTabsApi.md#listmenutabs) | **GET** /api/menus/{menuId}/tabs | List a menu&#39;s tabs |
| [**UpdateMenuTabById**](MenuTabsApi.md#updatemenutabbyid) | **PUT** /api/menus/{menuId}/tabs/{menuTabId} | Update menu tab by ID |

<a id="createmenutab"></a>
# **CreateMenuTab**
> MenuTabItselfResponse CreateMenuTab (Guid menuId, CreateMenuTabRequest createMenuTabRequest)

Create new menu tab


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **menuId** | **Guid** |  |  |
| **createMenuTabRequest** | [**CreateMenuTabRequest**](CreateMenuTabRequest.md) |  |  |

### Return type

[**MenuTabItselfResponse**](MenuTabItselfResponse.md)

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

<a id="deletemenutabbyid"></a>
# **DeleteMenuTabById**
> void DeleteMenuTabById (Guid menuId, Guid menuTabId)

Delete menu tab by ID


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **menuId** | **Guid** |  |  |
| **menuTabId** | **Guid** |  |  |

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

<a id="listmenutabs"></a>
# **ListMenuTabs**
> MenuTabListResponse ListMenuTabs (Guid menuId)

List a menu's tabs


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **menuId** | **Guid** |  |  |

### Return type

[**MenuTabListResponse**](MenuTabListResponse.md)

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

<a id="updatemenutabbyid"></a>
# **UpdateMenuTabById**
> MenuTabItselfResponse UpdateMenuTabById (Guid menuId, Guid menuTabId, UpdateMenuTabRequest updateMenuTabRequest)

Update menu tab by ID


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **menuId** | **Guid** |  |  |
| **menuTabId** | **Guid** |  |  |
| **updateMenuTabRequest** | [**UpdateMenuTabRequest**](UpdateMenuTabRequest.md) |  |  |

### Return type

[**MenuTabItselfResponse**](MenuTabItselfResponse.md)

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

