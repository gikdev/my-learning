# MenuTabsApi

All URIs are relative to *http://localhost:5482*

| Method | HTTP request | Description |
|------------- | ------------- | -------------|
| [**createMenuTab**](MenuTabsApi.md#createmenutaboperation) | **POST** /api/menus/{menuId}/tabs | Create new menu tab |
| [**deleteMenuTabById**](MenuTabsApi.md#deletemenutabbyid) | **DELETE** /api/menus/{menuId}/tabs/{menuTabId} | Delete menu tab by ID |
| [**listMenuTabs**](MenuTabsApi.md#listmenutabs) | **GET** /api/menus/{menuId}/tabs | List a menu\&#39;s tabs |
| [**updateMenuTabById**](MenuTabsApi.md#updatemenutabbyid) | **PUT** /api/menus/{menuId}/tabs/{menuTabId} | Update menu tab by ID |



## createMenuTab

> MenuTabItselfResponse createMenuTab(menuId, createMenuTabRequest)

Create new menu tab

### Example

```ts
import {
  Configuration,
  MenuTabsApi,
} from '';
import type { CreateMenuTabOperationRequest } from '';

async function example() {
  console.log("🚀 Testing  SDK...");
  const api = new MenuTabsApi();

  const body = {
    // string
    menuId: 38400000-8cf0-11bd-b23e-10b96e4ef00d,
    // CreateMenuTabRequest
    createMenuTabRequest: ...,
  } satisfies CreateMenuTabOperationRequest;

  try {
    const data = await api.createMenuTab(body);
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
| **createMenuTabRequest** | [CreateMenuTabRequest](CreateMenuTabRequest.md) |  | |

### Return type

[**MenuTabItselfResponse**](MenuTabItselfResponse.md)

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


## deleteMenuTabById

> deleteMenuTabById(menuId, menuTabId)

Delete menu tab by ID

### Example

```ts
import {
  Configuration,
  MenuTabsApi,
} from '';
import type { DeleteMenuTabByIdRequest } from '';

async function example() {
  console.log("🚀 Testing  SDK...");
  const api = new MenuTabsApi();

  const body = {
    // string
    menuId: 38400000-8cf0-11bd-b23e-10b96e4ef00d,
    // string
    menuTabId: 38400000-8cf0-11bd-b23e-10b96e4ef00d,
  } satisfies DeleteMenuTabByIdRequest;

  try {
    const data = await api.deleteMenuTabById(body);
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

### Return type

`void` (Empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#api-endpoints) [[Back to Model list]](../README.md#models) [[Back to README]](../README.md)


## listMenuTabs

> MenuTabListResponse listMenuTabs(menuId)

List a menu\&#39;s tabs

### Example

```ts
import {
  Configuration,
  MenuTabsApi,
} from '';
import type { ListMenuTabsRequest } from '';

async function example() {
  console.log("🚀 Testing  SDK...");
  const api = new MenuTabsApi();

  const body = {
    // string
    menuId: 38400000-8cf0-11bd-b23e-10b96e4ef00d,
  } satisfies ListMenuTabsRequest;

  try {
    const data = await api.listMenuTabs(body);
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

### Return type

[**MenuTabListResponse**](MenuTabListResponse.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: `application/json`


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#api-endpoints) [[Back to Model list]](../README.md#models) [[Back to README]](../README.md)


## updateMenuTabById

> MenuTabItselfResponse updateMenuTabById(menuId, menuTabId, updateMenuTabRequest)

Update menu tab by ID

### Example

```ts
import {
  Configuration,
  MenuTabsApi,
} from '';
import type { UpdateMenuTabByIdRequest } from '';

async function example() {
  console.log("🚀 Testing  SDK...");
  const api = new MenuTabsApi();

  const body = {
    // string
    menuId: 38400000-8cf0-11bd-b23e-10b96e4ef00d,
    // string
    menuTabId: 38400000-8cf0-11bd-b23e-10b96e4ef00d,
    // UpdateMenuTabRequest
    updateMenuTabRequest: ...,
  } satisfies UpdateMenuTabByIdRequest;

  try {
    const data = await api.updateMenuTabById(body);
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
| **updateMenuTabRequest** | [UpdateMenuTabRequest](UpdateMenuTabRequest.md) |  | |

### Return type

[**MenuTabItselfResponse**](MenuTabItselfResponse.md)

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

