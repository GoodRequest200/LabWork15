import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.remember
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import com.example.labwork18.ui.theme.LabWork18Theme
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.magnifier
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.OutlinedButton
import androidx.compose.material3.OutlinedTextField
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.ui.text.TextStyle
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.runtime.mutableStateOf
import androidx.compose.material3.TextField
import androidx.compose.ui.unit.sp
import androidx.compose.ui.graphics.Color
import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material.icons.Icons
import androidx.compose.runtime.derivedStateOf
import androidx.compose.ui.Alignment
import androidx.compose.ui.graphics.ImageBitmap
import androidx.compose.ui.graphics.vector.ImageVector
import androidx.compose.ui.res.imageResource
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.style.TextAlign


class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
//Task1                    RegistrationScreen()
//Task2                    ProductScreen()
                           ProductScreen2()
                }
            }
}

@Composable
fun ProductScreen2() {
    val products = remember { mutableStateOf(0) }

    Column(
        modifier = Modifier.padding(30.dp),
        horizontalAlignment = Alignment.CenterHorizontally // Center elements horizontally
    ) {
        Text(text = "Товар")

        Spacer(modifier = Modifier.height(30.dp))

        Text(text = "100 рублей")

        Spacer(modifier = Modifier.height(30.dp))

        Button(
            onClick = {
                products.value++
            },
            shape = RoundedCornerShape(16.dp)
        ) {
            Column(
                horizontalAlignment = Alignment.CenterHorizontally,
            ) {
                Image(
                    bitmap = ImageBitmap.imageResource(R.drawable.i),
                    contentDescription = "Product Image",
                    modifier = Modifier.size(50.dp)
                )
                Text(
                    text = "Добавить",
                    textAlign = TextAlign.Center
                )
            }
        }

        Spacer(modifier = Modifier.height(30.dp))

        Text(text = "Товаров заказано: ${products.value}")
    }
}

@Composable
fun ProductScreen(){

    val buttonText = remember{ mutableStateOf("Добавть в корзину") }
    val buttonColor = remember { mutableStateOf(0xff9ed6df) }

    Column (modifier = Modifier.padding(30.dp)){
        Spacer(Modifier.padding(30.dp))
        Text("Товар")
        Spacer(Modifier.padding(30.dp))
        Text("100 рублей")
        Spacer(Modifier.padding(30.dp))

        Button(colors = ButtonDefaults.buttonColors(
            contentColor = Color(0xff004D40),
            containerColor = Color(buttonColor.value)),
            onClick = {
                buttonText.value = "Перейти в корзину"
                buttonColor.value = 0xffd6df9e
        }){Text("${buttonText.value}")}
    }
}

@Composable
fun RegistrationScreen(){
    val login = remember {mutableStateOf("")}
    val password = remember {mutableStateOf("")}
    val authorizationLable = remember { mutableStateOf("")}

    Column(modifier = Modifier.padding(30.dp)) {
        Spacer(Modifier.padding(30.dp))
        OutlinedTextField(
            "${login.value}",
            placeholder = { Text("Login") },
            onValueChange = {newText -> login.value = newText})

        OutlinedTextField(
            "${password.value}",
            placeholder = { Text("Password") },
            onValueChange = {newText -> password.value = newText})

        OutlinedButton(onClick = {authorizationLable.value="${login.value}, ты в системе бро"}){
            Text("Authorization", fontSize = 25.sp)
        }

        Text("${authorizationLable.value}")
    }
}
