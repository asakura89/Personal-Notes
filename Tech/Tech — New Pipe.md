---
tags:
- Tech
date: 2024-11-24
---

# New Pipe

## sync subscription

1. open subscription screen
2. export to json
3. manually merge on vscode



## sync other data

1. open settings > backup and restore > export database
2. extract the zip
3. open sqlitestudio and load newpipe.db
4. move around the data manually
5. possible data to edit are playlists, remote_playlists, search_history
6. subscriptions better to use above steps
7. streams is a headache but needed for playlists_stream_join which needed for playlists
8. put back the newpipe.db into the zip
9. import the .zip into newpipe



## other way but never tried

1. https://github.com/yausername/newpipe-sync-server
