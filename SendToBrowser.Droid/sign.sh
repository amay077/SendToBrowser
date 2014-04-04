cp ./bin/Release/com.amay077.android.sendtobrowser.apk ./bin/Release/com.amay077.android.sendtobrowser-ReleaseSigned.apk
jarsigner -verbose -keystore $DBPATH/dev/Android/sendtobrowser.keystore ./bin/Release/com.amay077.android.sendtobrowser-ReleaseSigned.apk sendtobrowser
zipalign -f -v 4 ./bin/Release/com.amay077.android.sendtobrowser-ReleaseSigned.apk ./bin/Release/sendtobrowser.apk
cp ./bin/Release/sendtobrowser.apk ./apk
cp ./bin/Release/sendtobrowser.apk $DBPATH/apk