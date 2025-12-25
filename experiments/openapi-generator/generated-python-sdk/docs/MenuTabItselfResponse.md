# MenuTabItselfResponse


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **UUID** |  | 
**name** | **str** |  | 
**order** | **int** |  | 
**description** | **str** |  | [optional] 

## Example

```python
from openapi_client.models.menu_tab_itself_response import MenuTabItselfResponse

# TODO update the JSON string below
json = "{}"
# create an instance of MenuTabItselfResponse from a JSON string
menu_tab_itself_response_instance = MenuTabItselfResponse.from_json(json)
# print the JSON string representation of the object
print(MenuTabItselfResponse.to_json())

# convert the object into a dict
menu_tab_itself_response_dict = menu_tab_itself_response_instance.to_dict()
# create an instance of MenuTabItselfResponse from a dict
menu_tab_itself_response_from_dict = MenuTabItselfResponse.from_dict(menu_tab_itself_response_dict)
```
[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


