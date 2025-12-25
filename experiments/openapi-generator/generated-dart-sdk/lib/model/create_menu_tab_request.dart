//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.18

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class CreateMenuTabRequest {
  /// Returns a new [CreateMenuTabRequest] instance.
  CreateMenuTabRequest({
    required this.name,
    required this.order,
    this.description,
  });

  String name;

  int order;

  String? description;

  @override
  bool operator ==(Object other) => identical(this, other) || other is CreateMenuTabRequest &&
    other.name == name &&
    other.order == order &&
    other.description == description;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (name.hashCode) +
    (order.hashCode) +
    (description == null ? 0 : description!.hashCode);

  @override
  String toString() => 'CreateMenuTabRequest[name=$name, order=$order, description=$description]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
      json[r'name'] = this.name;
      json[r'order'] = this.order;
    if (this.description != null) {
      json[r'description'] = this.description;
    } else {
      json[r'description'] = null;
    }
    return json;
  }

  /// Returns a new [CreateMenuTabRequest] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static CreateMenuTabRequest? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "CreateMenuTabRequest[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "CreateMenuTabRequest[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return CreateMenuTabRequest(
        name: mapValueOfType<String>(json, r'name')!,
        order: mapValueOfType<int>(json, r'order')!,
        description: mapValueOfType<String>(json, r'description'),
      );
    }
    return null;
  }

  static List<CreateMenuTabRequest> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <CreateMenuTabRequest>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = CreateMenuTabRequest.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, CreateMenuTabRequest> mapFromJson(dynamic json) {
    final map = <String, CreateMenuTabRequest>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = CreateMenuTabRequest.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of CreateMenuTabRequest-objects as value to a dart map
  static Map<String, List<CreateMenuTabRequest>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<CreateMenuTabRequest>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = CreateMenuTabRequest.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
    'name',
    'order',
  };
}

