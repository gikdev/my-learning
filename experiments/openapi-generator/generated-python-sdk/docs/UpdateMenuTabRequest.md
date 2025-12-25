# UpdateMenuTabRequest


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**name** | **str** |  | 
**order** | **int** |  | 
**description** | **str** |  | [optional] 

## Example

```python
from openapi_client.models.update_menu_tab_request import UpdateMenuTabRequest

# TODO update the JSON string below
json = "{}"
# create an instance of UpdateMenuTabRequest from a JSON string
update_menu_tab_request_instance = UpdateMenuTabRequest.from_json(json)
# print the JSON string representation of the object
print(UpdateMenuTabRequest.to_json())

# convert the object into a dict
update_menu_tab_request_dict = update_menu_tab_request_instance.to_dict()
# create an instance of UpdateMenuTabRequest from a dict
update_menu_tab_request_from_dict = UpdateMenuTabRequest.from_dict(update_menu_tab_request_dict)
```
[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


