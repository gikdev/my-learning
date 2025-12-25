# openapi_client.MenuGroupsApi

All URIs are relative to *http://localhost:5482*

Method | HTTP request | Description
------------- | ------------- | -------------
[**create_menu_group**](MenuGroupsApi.md#create_menu_group) | **POST** /api/menus/{menuId}/tabs/{menuTabId}/groups | Create new menu group


# **create_menu_group**
> MenuGroupItselfResponse create_menu_group(menu_id, menu_tab_id, create_menu_group_request)

Create new menu group

### Example


```python
import openapi_client
from openapi_client.models.create_menu_group_request import CreateMenuGroupRequest
from openapi_client.models.menu_group_itself_response import MenuGroupItselfResponse
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
    api_instance = openapi_client.MenuGroupsApi(api_client)
    menu_id = UUID('38400000-8cf0-11bd-b23e-10b96e4ef00d') # UUID | 
    menu_tab_id = UUID('38400000-8cf0-11bd-b23e-10b96e4ef00d') # UUID | 
    create_menu_group_request = openapi_client.CreateMenuGroupRequest() # CreateMenuGroupRequest | 

    try:
        # Create new menu group
        api_response = api_instance.create_menu_group(menu_id, menu_tab_id, create_menu_group_request)
        print("The response of MenuGroupsApi->create_menu_group:\n")
        pprint(api_response)
    except Exception as e:
        print("Exception when calling MenuGroupsApi->create_menu_group: %s\n" % e)
```



### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **menu_id** | **UUID**|  | 
 **menu_tab_id** | **UUID**|  | 
 **create_menu_group_request** | [**CreateMenuGroupRequest**](CreateMenuGroupRequest.md)|  | 

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
**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

