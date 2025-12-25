//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class MenusApi {
  MenusApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Create new menu
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [CreateMenuRequest] createMenuRequest (required):
  Future<Response> createMenuWithHttpInfo(CreateMenuRequest createMenuRequest,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/menus';

    // ignore: prefer_final_locals
    Object? postBody = createMenuRequest;

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

  /// Create new menu
  ///
  /// Parameters:
  ///
  /// * [CreateMenuRequest] createMenuRequest (required):
  Future<MenuItselfResponse?> createMenu(CreateMenuRequest createMenuRequest,) async {
    final response = await createMenuWithHttpInfo(createMenuRequest,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'MenuItselfResponse',) as MenuItselfResponse;
    
    }
    return null;
  }

  /// Delete a menu by ID
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  Future<Response> deleteMenuByIdWithHttpInfo(String menuId,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/menus/{menuId}'
      .replaceAll('{menuId}', menuId);

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

  /// Delete a menu by ID
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  Future<void> deleteMenuById(String menuId,) async {
    final response = await deleteMenuByIdWithHttpInfo(menuId,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Duplicate a menu by ID
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  Future<Response> duplicateMenuByIdWithHttpInfo(String menuId,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/menus/{menuId}/duplicates'
      .replaceAll('{menuId}', menuId);

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    const contentTypes = <String>[];


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

  /// Duplicate a menu by ID
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  Future<MenuItselfResponse?> duplicateMenuById(String menuId,) async {
    final response = await duplicateMenuByIdWithHttpInfo(menuId,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'MenuItselfResponse',) as MenuItselfResponse;
    
    }
    return null;
  }

  /// List menus
  ///
  /// Note: This method returns the HTTP [Response].
  Future<Response> listMenusWithHttpInfo() async {
    // ignore: prefer_const_declarations
    final path = r'/api/menus';

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

  /// List menus
  Future<MenuListResponse?> listMenus() async {
    final response = await listMenusWithHttpInfo();
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'MenuListResponse',) as MenuListResponse;
    
    }
    return null;
  }

  /// Update a menu by ID
  ///
  /// Note: This method returns the HTTP [Response].
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  ///
  /// * [UpdateMenuRequest] updateMenuRequest (required):
  Future<Response> updateMenuByIdWithHttpInfo(String menuId, UpdateMenuRequest updateMenuRequest,) async {
    // ignore: prefer_const_declarations
    final path = r'/api/menus/{menuId}'
      .replaceAll('{menuId}', menuId);

    // ignore: prefer_final_locals
    Object? postBody = updateMenuRequest;

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

  /// Update a menu by ID
  ///
  /// Parameters:
  ///
  /// * [String] menuId (required):
  ///
  /// * [UpdateMenuRequest] updateMenuRequest (required):
  Future<void> updateMenuById(String menuId, UpdateMenuRequest updateMenuRequest,) async {
    final response = await updateMenuByIdWithHttpInfo(menuId, updateMenuRequest,);
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }
}
