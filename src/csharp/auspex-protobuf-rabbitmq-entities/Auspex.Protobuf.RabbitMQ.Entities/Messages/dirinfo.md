This file is here to make sure Git creates the Messages folder on the build host.
Protobuf code generation will fail if the Messages folder does not exist.
We could get rid of this file if the powershell build script is updated to create the directory if it's not there yet.