# ImsApiSdk.Api.MenuGroupsApi

All URIs are relative to *http://localhost:5482*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateMenuGroup**](MenuGroupsApi.md#createmenugroup) | **POST** /api/menus/{menuId}/tabs/{menuTabId}/groups | Create new menu group |

<a id="createmenugroup"></a>
# **CreateMenuGroup**
> MenuGroupItselfResponse CreateMenuGroup (Guid menuId, Guid menuTabId, CreateMenuGroupRequest createMenuGroupRequest)

Create new menu group


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **menuId** | **Guid** |  |  |
| **menuTabId** | **Guid** |  |  |
| **createMenuGroupRequest** | [**CreateMenuGroupRequest**](CreateMenuGroupRequest.md) |  |  |

### Return type

[**MenuGroupItselfResponse**](MenuGroupItselfResponse.md)

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

