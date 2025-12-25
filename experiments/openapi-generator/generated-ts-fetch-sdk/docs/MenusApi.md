# MenusApi

All URIs are relative to *http://localhost:5482*

| Method | HTTP request | Description |
|------------- | ------------- | -------------|
| [**createMenu**](MenusApi.md#createmenuoperation) | **POST** /api/menus | Create new menu |
| [**deleteMenuById**](MenusApi.md#deletemenubyid) | **DELETE** /api/menus/{menuId} | Delete a menu by ID |
| [**duplicateMenuById**](MenusApi.md#duplicatemenubyid) | **POST** /api/menus/{menuId}/duplicates | Duplicate a menu by ID |
| [**listMenus**](MenusApi.md#listmenus) | **GET** /api/menus | List menus |
| [**updateMenuById**](MenusApi.md#updatemenubyid) | **PUT** /api/menus/{menuId} | Update a menu by ID |



## createMenu

> MenuItselfResponse createMenu(createMenuRequest)

Create new menu

### Example

```ts
import {
  Configuration,
  MenusApi,
} from '';
import type { CreateMenuOperationRequest } from '';

async function example() {
  console.log("🚀 Testing  SDK...");
  const api = new MenusApi();

  const body = {
    // CreateMenuRequest
    createMenuRequest: ...,
  } satisfies CreateMenuOperationRequest;

  try {
    const data = await api.createMenu(body);
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
| **createMenuRequest** | [CreateMenuRequest](CreateMenuRequest.md) |  | |

### Return type

[**MenuItselfResponse**](MenuItselfResponse.md)

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


## deleteMenuById

> deleteMenuById(menuId)

Delete a menu by ID

### Example

```ts
import {
  Configuration,
  MenusApi,
} from '';
import type { DeleteMenuByIdRequest } from '';

async function example() {
  console.log("🚀 Testing  SDK...");
  const api = new MenusApi();

  const body = {
    // string
    menuId: 38400000-8cf0-11bd-b23e-10b96e4ef00d,
  } satisfies DeleteMenuByIdRequest;

  try {
    const data = await api.deleteMenuById(body);
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


## duplicateMenuById

> MenuItselfResponse duplicateMenuById(menuId)

Duplicate a menu by ID

### Example

```ts
import {
  Configuration,
  MenusApi,
} from '';
import type { DuplicateMenuByIdRequest } from '';

async function example() {
  console.log("🚀 Testing  SDK...");
  const api = new MenusApi();

  const body = {
    // string
    menuId: 38400000-8cf0-11bd-b23e-10b96e4ef00d,
  } satisfies DuplicateMenuByIdRequest;

  try {
    const data = await api.duplicateMenuById(body);
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

[**MenuItselfResponse**](MenuItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: `application/json`


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#api-endpoints) [[Back to Model list]](../README.md#models) [[Back to README]](../README.md)


## listMenus

> MenuListResponse listMenus()

List menus

### Example

```ts
import {
  Configuration,
  MenusApi,
} from '';
import type { ListMenusRequest } from '';

async function example() {
  console.log("🚀 Testing  SDK...");
  const api = new MenusApi();

  try {
    const data = await api.listMenus();
    console.log(data);
  } catch (error) {
    console.error(error);
  }
}

// Run the test
example().catch(console.error);
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**MenuListResponse**](MenuListResponse.md)

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


## updateMenuById

> updateMenuById(menuId, updateMenuRequest)

Update a menu by ID

### Example

```ts
import {
  Configuration,
  MenusApi,
} from '';
import type { UpdateMenuByIdRequest } from '';

async function example() {
  console.log("🚀 Testing  SDK...");
  const api = new MenusApi();

  const body = {
    // string
    menuId: 38400000-8cf0-11bd-b23e-10b96e4ef00d,
    // UpdateMenuRequest
    updateMenuRequest: ...,
  } satisfies UpdateMenuByIdRequest;

  try {
    const data = await api.updateMenuById(body);
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
| **updateMenuRequest** | [UpdateMenuRequest](UpdateMenuRequest.md) |  | |

### Return type

`void` (Empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: `application/json`
- **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#api-endpoints) [[Back to Model list]](../README.md#models) [[Back to README]](../README.md)

