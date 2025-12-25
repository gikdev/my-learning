//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class MenuTabsApi {
  MenuTabsApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Create new menu tab
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  ///
  /// * [CreateMenuTabRequest] createMenuTabRequest (required):
  Future<Response> createMenuTabWithHttpInfo(String menuId, CreateMenuTabRequest createMenuTabRequest,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/menus/{menuId}/tabs'
      .replaceAll('{menuId}', menuId);

    // ignore: prefer_final_locals
    Object? postBody = createMenuTabRequest;

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

  /// Create new menu tab
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  ///
  /// * [CreateMenuTabRequest] createMenuTabRequest (required):
  Future<MenuTabItselfResponse?> createMenuTab(String menuId, CreateMenuTabRequest createMenuTabRequest,) async {
    final response = await createMenuTabWithHttpInfo(menuId, createMenuTabRequest,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'MenuTabItselfResponse',) as MenuTabItselfResponse;
    
    }
    return null;
  }

  /// Delete menu tab by ID
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  ///
  /// * [String] menuTabId (required):
  Future<Response> deleteMenuTabByIdWithHttpInfo(String menuId, String menuTabId,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/menus/{menuId}/tabs/{menuTabId}'
      .replaceAll('{menuId}', menuId)
      .replaceAll('{menuTabId}', menuTabId);

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>[];


    return apiClient.invokeAPI(
      path,
      'DELETE',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Delete menu tab by ID
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  ///
  /// * [String] menuTabId (required):
  Future<void> deleteMenuTabById(String menuId, String menuTabId,) async {
    final response = await deleteMenuTabByIdWithHttpInfo(menuId, menuTabId,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// List a menu's tabs
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  Future<Response> listMenuTabsWithHttpInfo(String menuId,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/menus/{menuId}/tabs'
      .replaceAll('{menuId}', menuId);

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>[];


    return apiClient.invokeAPI(
      path,
      'GET',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// List a menu's tabs
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  Future<MenuTabListResponse?> listMenuTabs(String menuId,) async {
    final response = await listMenuTabsWithHttpInfo(menuId,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'MenuTabListResponse',) as MenuTabListResponse;
    
    }
    return null;
  }

  /// Update menu tab by ID
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  ///
  /// * [String] menuTabId (required):
  ///
  /// * [UpdateMenuTabRequest] updateMenuTabRequest (required):
  Future<Response> updateMenuTabByIdWithHttpInfo(String menuId, String menuTabId, UpdateMenuTabRequest updateMenuTabRequest,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/menus/{menuId}/tabs/{menuTabId}'
      .replaceAll('{menuId}', menuId)
      .replaceAll('{menuTabId}', menuTabId);

    // ignore: prefer_final_locals
    Object? postBody = updateMenuTabRequest;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>['application/json'];


    return apiClient.invokeAPI(
      path,
      'PUT',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Update menu tab by ID
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  ///
  /// * [String] menuTabId (required):
  ///
  /// * [UpdateMenuTabRequest] updateMenuTabRequest (required):
  Future<MenuTabItselfResponse?> updateMenuTabById(String menuId, String menuTabId, UpdateMenuTabRequest updateMenuTabRequest,) async {
    final response = await updateMenuTabByIdWithHttpInfo(menuId, menuTabId, updateMenuTabRequest,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'MenuTabItselfResponse',) as MenuTabItselfResponse;
    
    }
    return null;
  }
}
