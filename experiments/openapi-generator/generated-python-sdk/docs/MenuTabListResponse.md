# MenuTabListResponse


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**items** | [**List[MenuTabItselfResponse]**](MenuTabItselfResponse.md) |  | 

## Example

```python
from openapi_client.models.menu_tab_list_response import MenuTabListResponse

# TODO update the JSON string below
json = "{}"
# create an instance of MenuTabListResponse from a JSON string
menu_tab_list_response_instance = MenuTabListResponse.from_json(json)
# print the JSON string representation of the object
print(MenuTabListResponse.to_json())

# convert the object into a dict
menu_tab_list_response_dict = menu_tab_list_response_instance.to_dict()
# create an instance of MenuTabListResponse from a dict
menu_tab_list_response_from_dict = MenuTabListResponse.from_dict(menu_tab_list_response_dict)
```
[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


