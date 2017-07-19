# Elastic_Search_Sample_App
In this sample app of elasticsearch we are using C#.net WPF form to search data.


This is a sample C#.net project to show the working of elasticsearch. 

So first of all to run this project you need to install jdk (you can download it from here http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html )in your system and set the environment variable as variable name "JAVA_HOME" and varible path will be your jdk bin folder path after installation of jdk into your system. After setting up environment variable you need to download zip file of elasticsearch (you can download from here https://www.elastic.co/downloads/elasticsearch for windows download zip file ), then unzip this file. As soon as it unzipped it will installed elasticsearch. Then go to bin folder there run elasticsearch.bat file. After that type http://localhost:9200/ in your browser, if you get the JSON data as follows :


{
  "name" : "grAOKwH",
  "cluster_name" : "elasticsearch",
  "cluster_uuid" : "XPqFr6jLTcanZFz9tKTxOA",
  "version" : {
    "number" : "5.5.0",
    "build_hash" : "260387d",
    "build_date" : "2017-06-30T23:16:05.735Z",
    "build_snapshot" : false,
    "lucene_version" : "6.6.0"
  },
  "tagline" : "You Know, for Search"
}
