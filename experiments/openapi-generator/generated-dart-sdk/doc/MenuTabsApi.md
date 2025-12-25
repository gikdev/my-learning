# openapi.api.MenuTabsApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost:5482*

Method | HTTP request | Description
------------- | ------------- | -------------
[**createMenuTab**](MenuTabsApi.md#createmenutab) | **POST** /api/menus/{menuId}/tabs | Create new menu tab
[**deleteMenuTabById**](MenuTabsApi.md#deletemenutabbyid) | **DELETE** /api/menus/{menuId}/tabs/{menuTabId} | Delete menu tab by ID
[**listMenuTabs**](MenuTabsApi.md#listmenutabs) | **GET** /api/menus/{menuId}/tabs | List a menu's tabs
[**updateMenuTabById**](MenuTabsApi.md#updatemenutabbyid) | **PUT** /api/menus/{menuId}/tabs/{menuTabId} | Update menu tab by ID


# **createMenuTab**
> MenuTabItselfResponse createMenuTab(menuId, createMenuTabRequest)

Create new menu tab

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = MenuTabsApi();
final menuId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final createMenuTabRequest = CreateMenuTabRequest(); // CreateMenuTabRequest | 

try {
    final result = api_instance.createMenuTab(menuId, createMenuTabRequest);
    print(result);
} catch (e) {
    print('Exception when calling MenuTabsApi->createMenuTab: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menuId** | **String**|  | 
 **createMenuTabRequest** | [**CreateMenuTabRequest**](CreateMenuTabRequest.md)|  | 

### Return type

[**MenuTabItselfResponse**](MenuTabItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteMenuTabById**
> deleteMenuTabById(menuId, menuTabId)

Delete menu tab by ID

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = MenuTabsApi();
final menuId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final menuTabId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteMenuTabById(menuId, menuTabId);
} catch (e) {
    print('Exception when calling MenuTabsApi->deleteMenuTabById: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menuId** | **String**|  | 
 **menuTabId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listMenuTabs**
> MenuTabListResponse listMenuTabs(menuId)

List a menu's tabs

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = MenuTabsApi();
final menuId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    final result = api_instance.listMenuTabs(menuId);
    print(result);
} catch (e) {
    print('Exception when calling MenuTabsApi->listMenuTabs: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menuId** | **String**|  | 

### Return type

[**MenuTabListResponse**](MenuTabListResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateMenuTabById**
> MenuTabItselfResponse updateMenuTabById(menuId, menuTabId, updateMenuTabRequest)

Update menu tab by ID

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = MenuTabsApi();
final menuId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final menuTabId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final updateMenuTabRequest = UpdateMenuTabRequest(); // UpdateMenuTabRequest | 

try {
    final result = api_instance.updateMenuTabById(menuId, menuTabId, updateMenuTabRequest);
    print(result);
} catch (e) {
    print('Exception when calling MenuTabsApi->updateMenuTabById: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menuId** | **String**|  | 
 **menuTabId** | **String**|  | 
 **updateMenuTabRequest** | [**UpdateMenuTabRequest**](UpdateMenuTabRequest.md)|  | 

### Return type

[**MenuTabItselfResponse**](MenuTabItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

