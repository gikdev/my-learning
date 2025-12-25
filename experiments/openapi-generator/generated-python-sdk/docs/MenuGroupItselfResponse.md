# MenuGroupItselfResponse


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **UUID** |  | 
**name** | **str** |  | 
**order** | **int** |  | 
**description** | **str** |  | 
**image_url** | **str** |  | 

## Example

```python
from openapi_client.models.menu_group_itself_response import MenuGroupItselfResponse

# TODO update the JSON string below
json = "{}"
# create an instance of MenuGroupItselfResponse from a JSON string
menu_group_itself_response_instance = MenuGroupItselfResponse.from_json(json)
# print the JSON string representation of the object
print(MenuGroupItselfResponse.to_json())

# convert the object into a dict
menu_group_itself_response_dict = menu_group_itself_response_instance.to_dict()
# create an instance of MenuGroupItselfResponse from a dict
menu_group_itself_response_from_dict = MenuGroupItselfResponse.from_dict(menu_group_itself_response_dict)
```
[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


