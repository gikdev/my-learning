pnpm ogc generate -i ./api.json -g csharp -o ./generated-cs-sdk --additional-properties=packageName=ImsApiSdk,netCoreProjectFile=true,nullableReferenceTypes=true,targetFramework=net10.0
pnpm ogc generate -i ./api.json -g typescript-fetch -o ./generated-ts-fetch-sdk --additional-properties=fileNaming=kebab-case,withInterfaces=true
pnpm ogc generate -i ./api.json -g rust -o ./generated-rust-sdk
pnpm ogc generate -i ./api.json -g dart -o ./generated-dart-sdk
pnpm ogc generate -i ./api.json -g html -o ./generated-html-doc
pnpm ogc generate -i ./api.json -g html2 -o ./generated-html2-doc
pnpm ogc generate -i ./api.json -g dynamic-html -o ./generated-dynamic-html-doc
pnpm ogc generate -i ./api.json -g python -o ./generated-python-sdk
