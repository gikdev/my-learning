# CreateMenuGroupRequest


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**name** | **str** |  | 
**order** | **int** |  | 
**description** | **str** |  | [optional] 
**image_url** | **str** |  | [optional] 

## Example

```python
from openapi_client.models.create_menu_group_request import CreateMenuGroupRequest

# TODO update the JSON string below
json = "{}"
# create an instance of CreateMenuGroupRequest from a JSON string
create_menu_group_request_instance = CreateMenuGroupRequest.from_json(json)
# print the JSON string representation of the object
print(CreateMenuGroupRequest.to_json())

# convert the object into a dict
create_menu_group_request_dict = create_menu_group_request_instance.to_dict()
# create an instance of CreateMenuGroupRequest from a dict
create_menu_group_request_from_dict = CreateMenuGroupRequest.from_dict(create_menu_group_request_dict)
```
[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


