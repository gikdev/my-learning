# openapi.api.MenuGroupsApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost:5482*

Method | HTTP request | Description
------------- | ------------- | -------------
[**createMenuGroup**](MenuGroupsApi.md#createmenugroup) | **POST** /api/menus/{menuId}/tabs/{menuTabId}/groups | Create new menu group


# **createMenuGroup**
> MenuGroupItselfResponse createMenuGroup(menuId, menuTabId, createMenuGroupRequest)

Create new menu group

### Example
```dart
import 'package:openapi/api.dart';

final api_instance = MenuGroupsApi();
final menuId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final menuTabId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
final createMenuGroupRequest = CreateMenuGroupRequest(); // CreateMenuGroupRequest | 

try {
    final result = api_instance.createMenuGroup(menuId, menuTabId, createMenuGroupRequest);
    print(result);
} catch (e) {
    print('Exception when calling MenuGroupsApi->createMenuGroup: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menuId** | **String**|  | 
 **menuTabId** | **String**|  | 
 **createMenuGroupRequest** | [**CreateMenuGroupRequest**](CreateMenuGroupRequest.md)|  | 

### Return type

[**MenuGroupItselfResponse**](MenuGroupItselfResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

