# MenuGroupsApi

All URIs are relative to *http://localhost:5482*

| Method | HTTP request | Description |
|------------- | ------------- | -------------|
| [**createMenuGroup**](MenuGroupsApi.md#createmenugroupoperation) | **POST** /api/menus/{menuId}/tabs/{menuTabId}/groups | Create new menu group |



## createMenuGroup

> MenuGroupItselfResponse createMenuGroup(menuId, menuTabId, createMenuGroupRequest)

Create new menu group

### Example

```ts
import {
  Configuration,
  MenuGroupsApi,
} from '';
import type { CreateMenuGroupOperationRequest } from '';

async function example() {
  console.log("🚀 Testing  SDK...");
  const api = new MenuGroupsApi();

  const body = {
    // string
    menuId: 38400000-8cf0-11bd-b23e-10b96e4ef00d,
    // string
    menuTabId: 38400000-8cf0-11bd-b23e-10b96e4ef00d,
    // CreateMenuGroupRequest
    createMenuGroupRequest: ...,
  } satisfies CreateMenuGroupOperationRequest;

  try {
    const data = await api.createMenuGroup(body);
    console.log(data);
  } catch (error) {
    console.error(error);
  }
}

// Run the test
example().catch(console.error);
```

### Parameters


| Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **menuId** | `string` |  | [Defaults to `undefined`] |
| **menuTabId** | `string` |  | [Defaults to `undefined`] |
| **createMenuGroupRequest** | [CreateMenuGroupRequest](CreateMenuGroupRequest.md) |  | |

### Return type

[**MenuGroupItselfResponse**](MenuGroupItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: `application/json`
- **Accept**: `application/json`


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#api-endpoints) [[Back to Model list]](../README.md#models) [[Back to README]](../README.md)

