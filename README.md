# openhack

Proxies broken in v2 when using placeholders

The cause appears to be placeholder specialization. When going through specialization, in some cases it seems to be ignoring the proxies. When things work, the expected “Initializing Azure Function proxies” message is written during host startup, but in cases where the error occurs, this message is not written.

Fix:

A potential workaround is to set app setting WEBSITE_USE_PLACEHOLDER to 0 which will disable placeholders for the Function App. Setting this to 0 is a temporary fix (it will increase your cold start). Once this issue is fixed and released, you should remove this setting.
