# CreateMenuRequest


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**name** | **str** |  | 
**description** | **str** |  | [optional] 

## Example

```python
from openapi_client.models.create_menu_request import CreateMenuRequest

# TODO update the JSON string below
json = "{}"
# create an instance of CreateMenuRequest from a JSON string
create_menu_request_instance = CreateMenuRequest.from_json(json)
# print the JSON string representation of the object
print(CreateMenuRequest.to_json())

# convert the object into a dict
create_menu_request_dict = create_menu_request_instance.to_dict()
# create an instance of CreateMenuRequest from a dict
create_menu_request_from_dict = CreateMenuRequest.from_dict(create_menu_request_dict)
```
[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


