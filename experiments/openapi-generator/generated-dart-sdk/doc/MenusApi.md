# openapi.api.MenusApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost:5482*

Method | HTTP request | Description
------------- | ------------- | -------------
[**createMenu**](MenusApi.md#createmenu) | **POST** /api/menus | Create new menu
[**deleteMenuById**](MenusApi.md#deletemenubyid) | **DELETE** /api/menus/{menuId} | Delete a menu by ID
[**duplicateMenuById**](MenusApi.md#duplicatemenubyid) | **POST** /api/menus/{menuId}/duplicates | Duplicate a menu by ID
[**listMenus**](MenusApi.md#listmenus) | **GET** /api/menus | List menus
[**updateMenuById**](MenusApi.md#updatemenubyid) | **PUT** /api/menus/{menuId} | Update a menu by ID


# **createMenu**
> MenuItselfResponse createMenu(createMenuRequest)

Create new menu

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = MenusApi();
final createMenuRequest = CreateMenuRequest(); // CreateMenuRequest | 

try {
    final result = api_instance.createMenu(createMenuRequest);
    print(result);
} catch (e) {
    print('Exception when calling MenusApi->createMenu: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **createMenuRequest** | [**CreateMenuRequest**](CreateMenuRequest.md)|  | 

### Return type

[**MenuItselfResponse**](MenuItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteMenuById**
> deleteMenuById(menuId)

Delete a menu by ID

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = MenusApi();
final menuId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteMenuById(menuId);
} catch (e) {
    print('Exception when calling MenusApi->deleteMenuById: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menuId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **duplicateMenuById**
> MenuItselfResponse duplicateMenuById(menuId)

Duplicate a menu by ID

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = MenusApi();
final menuId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    final result = api_instance.duplicateMenuById(menuId);
    print(result);
} catch (e) {
    print('Exception when calling MenusApi->duplicateMenuById: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menuId** | **String**|  | 

### Return type

[**MenuItselfResponse**](MenuItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listMenus**
> MenuListResponse listMenus()

List menus

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = MenusApi();

try {
    final result = api_instance.listMenus();
    print(result);
} catch (e) {
    print('Exception when calling MenusApi->listMenus: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**MenuListResponse**](MenuListResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateMenuById**
> updateMenuById(menuId, updateMenuRequest)

Update a menu by ID

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = MenusApi();
final menuId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final updateMenuRequest = UpdateMenuRequest(); // UpdateMenuRequest | 

try {
    api_instance.updateMenuById(menuId, updateMenuRequest);
} catch (e) {
    print('Exception when calling MenusApi->updateMenuById: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menuId** | **String**|  | 
 **updateMenuRequest** | [**UpdateMenuRequest**](UpdateMenuRequest.md)|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

