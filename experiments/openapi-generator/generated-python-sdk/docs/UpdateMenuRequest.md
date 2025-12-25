# UpdateMenuRequest


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**name** | **str** |  | 
**description** | **str** |  | [optional] 

## Example

```python
from openapi_client.models.update_menu_request import UpdateMenuRequest

# TODO update the JSON string below
json = "{}"
# create an instance of UpdateMenuRequest from a JSON string
update_menu_request_instance = UpdateMenuRequest.from_json(json)
# print the JSON string representation of the object
print(UpdateMenuRequest.to_json())

# convert the object into a dict
update_menu_request_dict = update_menu_request_instance.to_dict()
# create an instance of UpdateMenuRequest from a dict
update_menu_request_from_dict = UpdateMenuRequest.from_dict(update_menu_request_dict)
```
[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


