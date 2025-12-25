# MenuItselfResponse


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **UUID** |  | 
**name** | **str** |  | 
**description** | **str** |  | [optional] 

## Example

```python
from openapi_client.models.menu_itself_response import MenuItselfResponse

# TODO update the JSON string below
json = "{}"
# create an instance of MenuItselfResponse from a JSON string
menu_itself_response_instance = MenuItselfResponse.from_json(json)
# print the JSON string representation of the object
print(MenuItselfResponse.to_json())

# convert the object into a dict
menu_itself_response_dict = menu_itself_response_instance.to_dict()
# create an instance of MenuItselfResponse from a dict
menu_itself_response_from_dict = MenuItselfResponse.from_dict(menu_itself_response_dict)
```
[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


