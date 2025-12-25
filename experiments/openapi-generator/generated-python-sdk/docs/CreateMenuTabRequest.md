# CreateMenuTabRequest


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**name** | **str** |  | 
**order** | **int** |  | 
**description** | **str** |  | [optional] 

## Example

```python
from openapi_client.models.create_menu_tab_request import CreateMenuTabRequest

# TODO update the JSON string below
json = "{}"
# create an instance of CreateMenuTabRequest from a JSON string
create_menu_tab_request_instance = CreateMenuTabRequest.from_json(json)
# print the JSON string representation of the object
print(CreateMenuTabRequest.to_json())

# convert the object into a dict
create_menu_tab_request_dict = create_menu_tab_request_instance.to_dict()
# create an instance of CreateMenuTabRequest from a dict
create_menu_tab_request_from_dict = CreateMenuTabRequest.from_dict(create_menu_tab_request_dict)
```
[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


