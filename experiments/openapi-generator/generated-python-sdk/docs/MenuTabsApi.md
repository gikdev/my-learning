# openapi_client.MenuTabsApi

All URIs are relative to *http://localhost:5482*

Method | HTTP request | Description
------------- | ------------- | -------------
[**create_menu_tab**](MenuTabsApi.md#create_menu_tab) | **POST** /api/menus/{menuId}/tabs | Create new menu tab
[**delete_menu_tab_by_id**](MenuTabsApi.md#delete_menu_tab_by_id) | **DELETE** /api/menus/{menuId}/tabs/{menuTabId} | Delete menu tab by ID
[**list_menu_tabs**](MenuTabsApi.md#list_menu_tabs) | **GET** /api/menus/{menuId}/tabs | List a menu&#39;s tabs
[**update_menu_tab_by_id**](MenuTabsApi.md#update_menu_tab_by_id) | **PUT** /api/menus/{menuId}/tabs/{menuTabId} | Update menu tab by ID


# **create_menu_tab**
> MenuTabItselfResponse create_menu_tab(menu_id, create_menu_tab_request)

Create new menu tab

### Example


```python
import openapi_client
from openapi_client.models.create_menu_tab_request import CreateMenuTabRequest
from openapi_client.models.menu_tab_itself_response import MenuTabItselfResponse
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
    api_instance = openapi_client.MenuTabsApi(api_client)
    menu_id = UUID('38400000-8cf0-11bd-b23e-10b96e4ef00d') # UUID | 
    create_menu_tab_request = openapi_client.CreateMenuTabRequest() # CreateMenuTabRequest | 

    try:
        # Create new menu tab
        api_response = api_instance.create_menu_tab(menu_id, create_menu_tab_request)
        print("The response of MenuTabsApi->create_menu_tab:\n")
        pprint(api_response)
    except Exception as e:
        print("Exception when calling MenuTabsApi->create_menu_tab: %s\n" % e)
```



### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menu_id** | **UUID**|  | 
 **create_menu_tab_request** | [**CreateMenuTabRequest**](CreateMenuTabRequest.md)|  | 

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
**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **delete_menu_tab_by_id**
> delete_menu_tab_by_id(menu_id, menu_tab_id)

Delete menu tab by ID

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
    api_instance = openapi_client.MenuTabsApi(api_client)
    menu_id = UUID('38400000-8cf0-11bd-b23e-10b96e4ef00d') # UUID | 
    menu_tab_id = UUID('38400000-8cf0-11bd-b23e-10b96e4ef00d') # UUID | 

    try:
        # Delete menu tab by ID
        api_instance.delete_menu_tab_by_id(menu_id, menu_tab_id)
    except Exception as e:
        print("Exception when calling MenuTabsApi->delete_menu_tab_by_id: %s\n" % e)
```



### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menu_id** | **UUID**|  | 
 **menu_tab_id** | **UUID**|  | 

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

# **list_menu_tabs**
> MenuTabListResponse list_menu_tabs(menu_id)

List a menu's tabs

### Example


```python
import openapi_client
from openapi_client.models.menu_tab_list_response import MenuTabListResponse
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
    api_instance = openapi_client.MenuTabsApi(api_client)
    menu_id = UUID('38400000-8cf0-11bd-b23e-10b96e4ef00d') # UUID | 

    try:
        # List a menu's tabs
        api_response = api_instance.list_menu_tabs(menu_id)
        print("The response of MenuTabsApi->list_menu_tabs:\n")
        pprint(api_response)
    except Exception as e:
        print("Exception when calling MenuTabsApi->list_menu_tabs: %s\n" % e)
```



### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menu_id** | **UUID**|  | 

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
**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **update_menu_tab_by_id**
> MenuTabItselfResponse update_menu_tab_by_id(menu_id, menu_tab_id, update_menu_tab_request)

Update menu tab by ID

### Example


```python
import openapi_client
from openapi_client.models.menu_tab_itself_response import MenuTabItselfResponse
from openapi_client.models.update_menu_tab_request import UpdateMenuTabRequest
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
    api_instance = openapi_client.MenuTabsApi(api_client)
    menu_id = UUID('38400000-8cf0-11bd-b23e-10b96e4ef00d') # UUID | 
    menu_tab_id = UUID('38400000-8cf0-11bd-b23e-10b96e4ef00d') # UUID | 
    update_menu_tab_request = openapi_client.UpdateMenuTabRequest() # UpdateMenuTabRequest | 

    try:
        # Update menu tab by ID
        api_response = api_instance.update_menu_tab_by_id(menu_id, menu_tab_id, update_menu_tab_request)
        print("The response of MenuTabsApi->update_menu_tab_by_id:\n")
        pprint(api_response)
    except Exception as e:
        print("Exception when calling MenuTabsApi->update_menu_tab_by_id: %s\n" % e)
```



### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menu_id** | **UUID**|  | 
 **menu_tab_id** | **UUID**|  | 
 **update_menu_tab_request** | [**UpdateMenuTabRequest**](UpdateMenuTabRequest.md)|  | 

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
**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

