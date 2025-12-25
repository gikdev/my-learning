# openapi_client.MenusApi

All URIs are relative to *http://localhost:5482*

Method | HTTP request | Description
------------- | ------------- | -------------
[**create_menu**](MenusApi.md#create_menu) | **POST** /api/menus | Create new menu
[**delete_menu_by_id**](MenusApi.md#delete_menu_by_id) | **DELETE** /api/menus/{menuId} | Delete a menu by ID
[**duplicate_menu_by_id**](MenusApi.md#duplicate_menu_by_id) | **POST** /api/menus/{menuId}/duplicates | Duplicate a menu by ID
[**list_menus**](MenusApi.md#list_menus) | **GET** /api/menus | List menus
[**update_menu_by_id**](MenusApi.md#update_menu_by_id) | **PUT** /api/menus/{menuId} | Update a menu by ID


# **create_menu**
> MenuItselfResponse create_menu(create_menu_request)

Create new menu

### Example


```python
import openapi_client
from openapi_client.models.create_menu_request import CreateMenuRequest
from openapi_client.models.menu_itself_response import MenuItselfResponse
from openapi_client.rest import ApiException
from pprint import pprint

# Defining the host is optional and defaults to http://localhost:5482
# See configuration.py for a list of all supported configuration parameters.
configuration = openapi_client.Configuration(
    host = "http://localhost:5482"
)


# Enter a context with an instance of the API client
with openapi_client.ApiClient(configuration) as api_client:
    # Create an instance of the API class
    api_instance = openapi_client.MenusApi(api_client)
    create_menu_request = openapi_client.CreateMenuRequest() # CreateMenuRequest | 

    try:
        # Create new menu
        api_response = api_instance.create_menu(create_menu_request)
        print("The response of MenusApi->create_menu:\n")
        pprint(api_response)
    except Exception as e:
        print("Exception when calling MenusApi->create_menu: %s\n" % e)
```



### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **create_menu_request** | [**CreateMenuRequest**](CreateMenuRequest.md)|  | 

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
**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **delete_menu_by_id**
> delete_menu_by_id(menu_id)

Delete a menu by ID

### Example


```python
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Defining the host is optional and defaults to http://localhost:5482
# See configuration.py for a list of all supported configuration parameters.
configuration = openapi_client.Configuration(
    host = "http://localhost:5482"
)


# Enter a context with an instance of the API client
with openapi_client.ApiClient(configuration) as api_client:
    # Create an instance of the API class
    api_instance = openapi_client.MenusApi(api_client)
    menu_id = UUID('38400000-8cf0-11bd-b23e-10b96e4ef00d') # UUID | 

    try:
        # Delete a menu by ID
        api_instance.delete_menu_by_id(menu_id)
    except Exception as e:
        print("Exception when calling MenusApi->delete_menu_by_id: %s\n" % e)
```



### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menu_id** | **UUID**|  | 

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
**204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **duplicate_menu_by_id**
> MenuItselfResponse duplicate_menu_by_id(menu_id)

Duplicate a menu by ID

### Example


```python
import openapi_client
from openapi_client.models.menu_itself_response import MenuItselfResponse
from openapi_client.rest import ApiException
from pprint import pprint

# Defining the host is optional and defaults to http://localhost:5482
# See configuration.py for a list of all supported configuration parameters.
configuration = openapi_client.Configuration(
    host = "http://localhost:5482"
)


# Enter a context with an instance of the API client
with openapi_client.ApiClient(configuration) as api_client:
    # Create an instance of the API class
    api_instance = openapi_client.MenusApi(api_client)
    menu_id = UUID('38400000-8cf0-11bd-b23e-10b96e4ef00d') # UUID | 

    try:
        # Duplicate a menu by ID
        api_response = api_instance.duplicate_menu_by_id(menu_id)
        print("The response of MenusApi->duplicate_menu_by_id:\n")
        pprint(api_response)
    except Exception as e:
        print("Exception when calling MenusApi->duplicate_menu_by_id: %s\n" % e)
```



### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menu_id** | **UUID**|  | 

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
**201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **list_menus**
> MenuListResponse list_menus()

List menus

### Example


```python
import openapi_client
from openapi_client.models.menu_list_response import MenuListResponse
from openapi_client.rest import ApiException
from pprint import pprint

# Defining the host is optional and defaults to http://localhost:5482
# See configuration.py for a list of all supported configuration parameters.
configuration = openapi_client.Configuration(
    host = "http://localhost:5482"
)


# Enter a context with an instance of the API client
with openapi_client.ApiClient(configuration) as api_client:
    # Create an instance of the API class
    api_instance = openapi_client.MenusApi(api_client)

    try:
        # List menus
        api_response = api_instance.list_menus()
        print("The response of MenusApi->list_menus:\n")
        pprint(api_response)
    except Exception as e:
        print("Exception when calling MenusApi->list_menus: %s\n" % e)
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

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **update_menu_by_id**
> update_menu_by_id(menu_id, update_menu_request)

Update a menu by ID

### Example


```python
import openapi_client
from openapi_client.models.update_menu_request import UpdateMenuRequest
from openapi_client.rest import ApiException
from pprint import pprint

# Defining the host is optional and defaults to http://localhost:5482
# See configuration.py for a list of all supported configuration parameters.
configuration = openapi_client.Configuration(
    host = "http://localhost:5482"
)


# Enter a context with an instance of the API client
with openapi_client.ApiClient(configuration) as api_client:
    # Create an instance of the API class
    api_instance = openapi_client.MenusApi(api_client)
    menu_id = UUID('38400000-8cf0-11bd-b23e-10b96e4ef00d') # UUID | 
    update_menu_request = openapi_client.UpdateMenuRequest() # UpdateMenuRequest | 

    try:
        # Update a menu by ID
        api_instance.update_menu_by_id(menu_id, update_menu_request)
    except Exception as e:
        print("Exception when calling MenusApi->update_menu_by_id: %s\n" % e)
```



### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menu_id** | **UUID**|  | 
 **update_menu_request** | [**UpdateMenuRequest**](UpdateMenuRequest.md)|  | 

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
**204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

