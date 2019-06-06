import {
    createAppContainer,
    createStackNavigator,
    createSwitchNavigator
} from "react-navigation";

import ListaPizzaria from "./pages/listaPizzaria";
import Login from "./pages/login";

const AuthStack = createStackNavigator({ Login });

const ListaPizzariaNavigator = createStackNavigator(
    {
        ListaPizzaria
    }
);

export default createAppContainer(
    createSwitchNavigator(
        {
            ListaPizzariaNavigator,
            AuthStack
        },
        {
            initialRouteName: "AuthStack"
        }
    )
);