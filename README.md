# Kafka
Kafka with 2 consumers on .net 5


install zookeeper
http://zookeeper.apache.org/releases.html#download
install kafka 
https://kafka.apache.org/downloads (binary download)
create zookeeper and kafka enviorment varibles

start zookeeper
zkserver
start kafka
kafka-server-start.bat %KAFKA_HOME%\config\server.properties 

create topic

kafka-topics.bat --create --zookeeper localhost:2181 --replication-factor 1 --partitions 3 --topic deneme
