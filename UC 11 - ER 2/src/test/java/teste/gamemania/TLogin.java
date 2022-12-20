package teste.gamemania;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;


public class TLogin {
	
	private WebDriver driver;
	
	@Before 
	public void ConfigurarTeste() {
		System.setProperty("webdriver.chrome.driver", "C:\\Program Files\\Chromedriver\\chromedriver.exe");
		driver = new ChromeDriver();
		driver.manage().window().maximize();
		driver.get("http://localhost:4200/");
		driver.findElement(By.xpath("/html/body/app-root/app-header/header/nav[2]/a[3]")).click();
	}

	@Test
	public void TestarLogin() {
		WebElement campoemail = driver.findElement(By.id("email"));
		WebElement camposenha = driver.findElement(By.id("password"));
		WebElement botao = driver.findElement(By.xpath("/html/body/app-root/app-login/main/div/div[2]/form/button"));
		
		String[] listaemails = {"matilda@hotmail.com", "katniss@email.com", "homemaranha@email.com"};
		String[] listasenhas = {"oitudobem", "katniss", "teia"};
		
		try {
			
			for(int contador = 0; contador < 3; contador ++) {
				campoemail.sendKeys(listaemails[contador]);
				camposenha.sendKeys(listasenhas[contador]);
				botao.click();
				
				Thread.sleep(3000);
				campoemail.clear();
				camposenha.clear();
			}
			
			/* 
			//email incorreto
			campoemail.sendKeys("matilda@hotmail.com");
			camposenha.sendKeys("oitudobem");
			botao.click();
					
			Thread.sleep(5000);
			campoemail.clear();
			camposenha.clear();
			
			//senha incorreta//
			campoemail.sendKeys("harrypotter@email.com");
			camposenha.sendKeys("oitudobem");
			botao.click();
			
			Thread.sleep(5000);
			campoemail.clear();
			camposenha.clear();
			
			//  login 
			campoemail.sendKeys("harrypotter@email.com");
			camposenha.sendKeys("avadakedavra");
			botao.click();  */
			
			
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	}
	
	@After 
	public void FinalizarTeste( ) {
		
	}
}
