//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class MenuTabItselfResponse {
  /// Returns a new [MenuTabItselfResponse] instance.
  MenuTabItselfResponse({
    required this.id,
    required this.name,
    required this.order,
    this.description,
  });

  String id;

  String name;

  int order;

  String? description;

  @override
  bool operator ==(Object other) => identical(this, other) || other is MenuTabItselfResponse &&
    other.id == id &&
    other.name == name &&
    other.order == order &&
    other.description == description;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id.hashCode) +
    (name.hashCode) +
    (order.hashCode) +
    (description == null ? 0 : description!.hashCode);

  @override
  String toString() => 'MenuTabItselfResponse[id=$id, name=$name, order=$order, description=$description]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
      json[r'id'] = this.id;
      json[r'name'] = this.name;
      json[r'order'] = this.order;
    if (this.description != null) {
      json[r'description'] = this.description;
    } else {
      json[r'description'] = null;
    }
    return json;
  }

  /// Returns a new [MenuTabItselfResponse] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static MenuTabItselfResponse? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "MenuTabItselfResponse[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "MenuTabItselfResponse[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return MenuTabItselfResponse(
        id: mapValueOfType<String>(json, r'id')!,
        name: mapValueOfType<String>(json, r'name')!,
        order: mapValueOfType<int>(json, r'order')!,
        description: mapValueOfType<String>(json, r'description'),
      );
    }
    return null;
  }

  static List<MenuTabItselfResponse> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <MenuTabItselfResponse>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = MenuTabItselfResponse.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, MenuTabItselfResponse> mapFromJson(dynamic json) {
    final map = <String, MenuTabItselfResponse>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = MenuTabItselfResponse.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of MenuTabItselfResponse-objects as value to a dart map
  static Map<String, List<MenuTabItselfResponse>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<MenuTabItselfResponse>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = MenuTabItselfResponse.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
    'id',
    'name',
    'order',
  };
}

