import React, { Component } from "react";

import { Text, StyleSheet, View, FlatList, TouchableOpacity, AsyncStorage, ImageBackground } from "react-native";

import api from "../services/api";
import Login from "./login";

class ListaPizzaria extends Component{
    constructor(pros){
        super(props);
        this.state = {
            listaPizzaria: [],
            token: ""
        };
    }

    static navigationOptions = {
        header: null
    }

    componentDidMount(){
        this.carregarPizzaria();
    }

    carregarPizzaria = async () =>{
        try{
            let token = await AsyncStorage.getItem('userToken');
            const resposta = await api.get('/pizzaria',{
                headers: {
                    "Content-Type": "application/json",
                    'Authorization': "Bearer " + token
                  }
            });
            const dadosDaApi = resposta.data;
            console.warn(dadosDaApi)
            this.setState({ listaPizzaria: dadosDaApi});
        }catch(error){
            alert('ERROR'+ error);
        }
    }

    render(){
        return(
            <View style={styles.main}>
           
              <TouchableOpacity
                onPress={() => {
                  this.props.navigation.navigate("Login")
                  AsyncStorage.removeItem("userToken")
                }}
              ><Text style={styles.sair}>Sair</Text></TouchableOpacity>
              <View style={styles.duas}>
                <Text style={styles.mainHeaderText}>{"ListaPizzaria".toUpperCase()}</Text>
                <View style={styles.mainHeaderLine} />
              </View>
           
    
    
            <View style={styles.mainBody}>
              <FlatList
                contentContainerStyle={styles.mainBodyConteudo}
                data={this.state.listaPizzaria}
                keyExtractor={item => item.id}
                renderItem={this.renderizaItem}
              />
            </View>
          </View>
        );
    }

    renderItem = ({item}) => (

        <View style={styles.flatItemLinha}>



        <View style={styles.flatItemContainer}>
  
          <Text style={styles.flatItemNomeLista}>Nome:</Text>
          <Text style={styles.flatItemNome}>{item.idCategoriaNavigation.nome}</Text>
  
          <Text style={styles.flatItemNomeLista}>Endereço:</Text>
          <Text style={styles.flatItemNome}>{item.endereco}</Text>
  
          <Text style={styles.flatItemNomeLista}>Vegana:</Text>
          <Text style={styles.flatItemNome}>{item.vegana}</Text>
  
          <Text style={styles.flatItemNomeLista}>Telefone:</Text>
          <Text style={styles.flatItemNome}>{item.telefone}</Text>
  
          <Text style={styles.flatItemNomeLista}>Nome Categoria:</Text>
          <Text style={styles.flatItemNome}>{item.dataCons}</Text>

          
          <Text style={styles.flatItemNomeLista}>Descricão da Categoria:</Text>
          <Text style={styles.flatItemNome}>{item.dataCons}</Text>
  
          <Text style={styles.flatItem}></Text>
          <View style={styles.mainHeaderLineFinal} />
        </View>
      </View>
  
        //id
        //nome
        //endereço
        //vegana
        //telefone
        //idCategoriaNavigation.nome
        //idcategoriaNavigation.descricao
    );
}

export default ListaPizzaria;