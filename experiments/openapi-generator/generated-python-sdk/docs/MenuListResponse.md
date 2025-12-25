# MenuListResponse


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**items** | [**List[MenuItselfResponse]**](MenuItselfResponse.md) |  | 

## Example

```python
from openapi_client.models.menu_list_response import MenuListResponse

# TODO update the JSON string below
json = "{}"
# create an instance of MenuListResponse from a JSON string
menu_list_response_instance = MenuListResponse.from_json(json)
# print the JSON string representation of the object
print(MenuListResponse.to_json())

# convert the object into a dict
menu_list_response_dict = menu_list_response_instance.to_dict()
# create an instance of MenuListResponse from a dict
menu_list_response_from_dict = MenuListResponse.from_dict(menu_list_response_dict)
```
[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


