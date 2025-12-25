//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class MenuGroupsApi {
  MenuGroupsApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Create new menu group
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  ///
  /// * [String] menuTabId (required):
  ///
  /// * [CreateMenuGroupRequest] createMenuGroupRequest (required):
  Future<Response> createMenuGroupWithHttpInfo(String menuId, String menuTabId, CreateMenuGroupRequest createMenuGroupRequest,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/menus/{menuId}/tabs/{menuTabId}/groups'
      .replaceAll('{menuId}', menuId)
      .replaceAll('{menuTabId}', menuTabId);

    // ignore: prefer_final_locals
    Object? postBody = createMenuGroupRequest;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>['application/json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Create new menu group
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  ///
  /// * [String] menuTabId (required):
  ///
  /// * [CreateMenuGroupRequest] createMenuGroupRequest (required):
  Future<MenuGroupItselfResponse?> createMenuGroup(String menuId, String menuTabId, CreateMenuGroupRequest createMenuGroupRequest,) async {
    final response = await createMenuGroupWithHttpInfo(menuId, menuTabId, createMenuGroupRequest,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'MenuGroupItselfResponse',) as MenuGroupItselfResponse;
    
    }
    return null;
  }
}
