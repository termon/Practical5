{ pkgs }: {
	deps = [
		pkgs.dotnet-sdk_7
        pkgs.omnisharp-roslyn
        pkgs.zip
        pkgs.unzip
        pkgs.sqlite
	];
}